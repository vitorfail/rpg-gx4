import json

ARQUIVO_JSON_2 = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\magias_circulo2.json"

# Ler o arquivo JSON
with open(ARQUIVO_JSON_2, "r", encoding="utf-8") as f:
    dados = json.load(f)

# Adicionar o índice começando em 1
for i, objeto in enumerate(dados, start=1):
    objeto["index"] = i

# Salvar o JSON atualizado
with open(ARQUIVO_JSON_2, "w", encoding="utf-8") as f:
    json.dump(dados, f, ensure_ascii=False, indent=4)

print("Índices adicionados com sucesso!")
