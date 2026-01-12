import json
import re

CAMINHO_JSON = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\magias.json"

MULTIPLICADORES = {
    "segundo": 1,
    "segundos": 1,
    "minuto": 60,
    "minutos": 60,
    "hora": 3600,
    "horas": 3600,
    "dia": 86400,
    "dias": 86400,
}

PADRAO_DURACAO = re.compile(
    r"duração\s*:?\s*(?:concentração,\s*)?(?:até\s*)?(\d+)\s*(segundos?|minutos?|horas?|dias?)",
    re.IGNORECASE
)

def extrair_duracao(titulo: str) -> int:
    titulo_lower = titulo.lower()

    # Instantânea
    if "instantânea" in titulo_lower:
        return 1

    match = PADRAO_DURACAO.search(titulo_lower)
    if not match:
        return -1

    quantidade = int(match.group(1))
    unidade = match.group(2)

    segundos = quantidade * MULTIPLICADORES[unidade]

    # converte para turnos de 6 segundos
    return segundos // 6


def processar_magias():
    with open(CAMINHO_JSON, "r", encoding="utf-8") as f:
        magias = json.load(f)

    falhas = 0

    for magia in magias:
        titulo = magia.get("titulo", "")
        duracao = extrair_duracao(titulo)

        magia["duracao"] = duracao

        if duracao == -1:
            falhas += 1

    with open(CAMINHO_JSON, "w", encoding="utf-8") as f:
        json.dump(magias, f, ensure_ascii=False, indent=4)

    print(f"✔ JSON atualizado com sucesso. Durações não reconhecidas: {falhas}")


if __name__ == "__main__":
    processar_magias()
