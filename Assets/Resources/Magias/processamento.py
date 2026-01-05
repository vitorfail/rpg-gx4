import json
import os
import unicodedata
from difflib import SequenceMatcher

# Caminhos
json_path = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\magias.json"
audio_folder = r"C:\Users\vitor\rpg-gx4\Assets\Resources\Magias\Voice\Mulher"

# Função para remover acentos
def remove_acentos(s):
    return ''.join(c for c in unicodedata.normalize('NFD', s)
                   if unicodedata.category(c) != 'Mn')

# Função para normalizar strings para comparação
def normalizar(s):
    s = remove_acentos(s.lower())
    # substitui espaços, hífens e underscores por espaço
    for c in ['_', '-', '.']:
        s = s.replace(c, ' ')
    # remove palavras extras desnecessárias (opcional)
    s = ' '.join(s.split())  # remove múltiplos espaços
    return s

# Função para medir similaridade por palavras
def similar_palavras(a, b):
    a_tokens = set(a.split())
    b_tokens = set(b.split())
    intersection = len(a_tokens & b_tokens)
    union = len(a_tokens | b_tokens)
    if union == 0:
        return 0
    return intersection / union  # Jaccard similarity

# Carrega JSON
with open(json_path, 'r', encoding='utf-8') as f:
    magias = json.load(f)

# Lista inicial de áudios
audios = [f for f in os.listdir(audio_folder) if f.endswith(".mp3")]

# Processa cada magia
for magia_nome, magia_num in magias.items():
    magia_normal = normalizar(magia_nome)
    
    melhor_match = None
    melhor_score = 0
    
    for audio in audios:
        audio_base = normalizar(os.path.splitext(audio)[0])
        score = similar_palavras(magia_normal, audio_base)
        if score > melhor_score:
            melhor_score = score
            melhor_match = audio
    
    # Ajuste de threshold: palavras correspondentes > 0.5
    if melhor_score > 0.5 and melhor_match:
        antigo_caminho = os.path.join(audio_folder, melhor_match)
        if os.path.exists(antigo_caminho):
            novo_nome = f"{magia_num}- {melhor_match}"
            novo_caminho = os.path.join(audio_folder, novo_nome)
            os.rename(antigo_caminho, novo_caminho)
            print(f"{melhor_match} -> {novo_nome} (similaridade: {melhor_score:.2f})")
            # Atualiza lista de áudios
            audios = [f for f in audios if f != melhor_match]
        else:
            print(f"Arquivo não encontrado: {antigo_caminho}")
    else:
        print(f"Nenhum match bom encontrado para: {magia_nome}")
