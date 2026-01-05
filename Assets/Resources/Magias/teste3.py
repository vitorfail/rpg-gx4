import json

# Caminho do arquivo
caminho = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\magias_circulo2.json"

# Ler o arquivo JSON
with open(caminho, "r", encoding="utf-8") as f:
    dados = json.load(f)

# Remover a chave "index" de cada objeto
for objeto in dados:
    objeto.pop("index", None)  # None evita erro se não existir

# Salvar o JSON de volta no arquivo
with open(caminho, "w", encoding="utf-8") as f:
    json.dump(dados, f, ensure_ascii=False, indent=4)

print("Chave 'index' removida com sucesso.")
