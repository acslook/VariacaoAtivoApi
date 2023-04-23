CREATE TABLE posicao_ativo (
	codigo_ativo varchar(30) NOT NULL,
	data_posicao date NOT NULL,
	valor_posicao numeric(18, 2) NULL,
	CONSTRAINT variacao_ativos_pk PRIMARY KEY (codigo_ativo, data_posicao)
);