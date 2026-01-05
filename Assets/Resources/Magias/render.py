import json
import os
import google.generativeai as genai

CAMINHO_JSON = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\magias.json"

genai.configure(api_key=os.getenv("AIzaSyASSA_N1KUAI4nfonTJ1AlYmNICp_P9v98"))

model = genai.GenerativeModel("gemini-1.5-flash")

PROMPT_BASE = """
Extraia a duração da magia a partir do texto abaixo.

Retorne APENAS um número inteiro representando a duração em turnos de 6 segundos.

Regras:
- Instantânea → 1
- 1 minuto → 10
- 1 hora → 600
- 1 dia → 14400
- Se não for possível determinar → -1

Texto:
"{texto}"
"""

def duracao_com_gemini(titulo):
    prompt = PROMPT_BASE.format(texto=titulo)

    response = model.generate_content(prompt)

    try:
        return int(response.text.strip())
    except ValueError:
        return -1


def processar_magias():
    with open(CAMINHO_JSON, "r", encoding="utf-8") as f:
        magias = json.load(f)

    for magia in magias:
        titulo = magia.get("titulo", "")
        magia["duracao"] = duracao_com_gemini(titulo)

    with open(CAMINHO_JSON, "w", encoding="utf-8") as f:
        json.dump(magias, f, ensure_ascii=False, indent=4)

    print("✔ Durações interpretadas com Gemini!")


if __name__ == "__main__":
    processar_magias()
