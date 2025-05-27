-- Extensão necessária para UUIDs aleatórios
CREATE EXTENSION IF NOT EXISTS "pgcrypto";

-- Tabela de usuários
CREATE TABLE users (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    google_sub TEXT UNIQUE NOT NULL,
    created_at TIMESTAMP DEFAULT NOW()
);

-- Tabela de personagens
CREATE TABLE characters (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    user_id UUID REFERENCES users(id) ON DELETE CASCADE,

    name TEXT NOT NULL,
    level INT DEFAULT 1,
    xp INT DEFAULT 0,
    win INT DEFAULT 0,
    lose INT DEFAULT 0,

    class INT NOT NULL,
    subclass INT,
    subclass_traits INT[],     -- Array de características da subclasse
    magias INT[],              -- Magias
    is_summoner BOOLEAN DEFAULT FALSE, -- conj

    forca INT,
    destreza INT,
    constituicao INT,
    inteligencia INT,
    sabedoria INT,
    carisma INT,

    raca INT,
    sexo INT,
    cor FLOAT[3],            -- cor (RGB normalizado, ex: [0.5, 0.2, 0.7])

    talentos INT[],
    armas INT[],
    attack_effect INT,

    created_at TIMESTAMP DEFAULT NOW()
);

-- Índices úteis
CREATE INDEX idx_user_google_sub ON users(google_sub);
CREATE INDEX idx_character_user_id ON characters(user_id);