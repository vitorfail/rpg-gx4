import json
from difflib import SequenceMatcher

# ---------- CONFIGURAÇÕES ----------
ARQUIVO_JSON_1 = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\magias.json"   # {"Acalmar Emoções": "1", ...}
ARQUIVO_JSON_2 = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\magias_circulo2.json"  # [{ "nome": "ACALMAR EMOÇÕES", ... }]
LIMIAR_SIMILARIDADE = 0.85            # 85% costuma funcionar bem
# ----------------------------------


def normalizar(texto):
    return texto.strip().lower()


def similaridade(a, b):
    return SequenceMatcher(None, a, b).ratio()


# Carregar arquivos
with open(ARQUIVO_JSON_1, encoding="utf-8") as f:
    json1 = json.load(f)

with open(ARQUIVO_JSON_2, encoding="utf-8") as f:
    json2 = json.load(f)

# Nomes do primeiro JSON (chaves)
nomes_json1 = [normalizar(nome) for nome in json1.keys()]

# Nomes do segundo JSON
nomes_json2 = [normalizar(item["nome"]) for item in json2]

faltando = []

for nome1 in nomes_json1:
    melhor_similaridade = 0

    for nome2 in nomes_json2:
        sim = similaridade(nome1, nome2)
        melhor_similaridade = max(melhor_similaridade, sim)

    if melhor_similaridade < LIMIAR_SIMILARIDADE:
        faltando.append(nome1)

# Resultado
print("Magias possivelmente faltando no segundo JSON:\n")
for nome in faltando:
    print(f"- {nome}")

print(f"\nTotal faltando: {len(faltando)}")
