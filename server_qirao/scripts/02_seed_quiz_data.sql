-- ============================================
-- Datos semilla: quiz_levels + quiz_questions
-- Basado en quiz_data.json del Flutter
-- ============================================

-- Niveles (Mapa 1: niveles 1-6, Mapa 2: niveles 7-12, Mapa 3: niveles 13-18)
INSERT INTO quiz_levels (Id, Number, Name, Mapa) VALUES
('1',  1,  'Nivel 1',  'Mapa 1'),
('2',  2,  'Nivel 2',  'Mapa 1'),
('3',  3,  'Nivel 3',  'Mapa 1'),
('4',  4,  'Nivel 4',  'Mapa 1'),
('5',  5,  'Nivel 5',  'Mapa 1'),
('6',  6,  'Nivel 6',  'Mapa 1'),
('7',  7,  'Nivel 7',  'Mapa 2'),
('8',  8,  'Nivel 8',  'Mapa 2'),
('9',  9,  'Nivel 9',  'Mapa 2'),
('10', 10, 'Nivel 10', 'Mapa 2'),
('11', 11, 'Nivel 11', 'Mapa 2'),
('12', 12, 'Nivel 12', 'Mapa 2'),
('13', 13, 'Nivel 13', 'Mapa 3'),
('14', 14, 'Nivel 14', 'Mapa 3'),
('15', 15, 'Nivel 15', 'Mapa 3'),
('16', 16, 'Nivel 16', 'Mapa 3'),
('17', 17, 'Nivel 17', 'Mapa 3'),
('18', 18, 'Nivel 18', 'Mapa 3');

-- Preguntas por nivel
-- Nivel 1 (1 pregunta)
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('1', '¿Cómo se llama el lugar?', '["Plaza hanan","Plaza principal","Sol de llamas"]', 'What is the name of this place?', '["Hanan plaza","Main plaza","Sun of llamas"]', 'assets/modules/quiz/questions/pregunta1.png', 1);

-- Nivel 2 (2 preguntas)
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('2', '¿Cuál es el río más cercano a Choquequirao?', '["Urubamba","Apurímac","Amazonas"]', 'Which river is closest to Choquequirao?', '["Urubamba","Apurímac","Amazon"]', 'assets/modules/quiz/questions/pregunta2.png', 1),
('2', '¿Qué animal es símbolo andino por excelencia?', '["Llama","Serpiente","Cóndor"]', 'Which animal is the quintessential Andean symbol?', '["Llama","Snake","Condor"]', 'assets/modules/quiz/questions/pregunta2.png', 0);

-- Nivel 3
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('3', '¿En qué sector está el Usno?', '["Sector I","Sector II","Sector VIII"]', 'In which sector is the Usno located?', '["Sector I","Sector II","Sector VIII"]', 'assets/modules/quiz/questions/pregunta3.png', 2);

-- Nivel 4
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('4', '¿Cuál es la función principal del Usno?', '["Ceremonial","Vivienda","Almacén"]', 'What is the main function of the Usno?', '["Ceremonial","Dwelling","Storage"]', 'assets/modules/quiz/questions/pregunta4.png', 0);

-- Nivel 5
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('5', '¿Qué cultura construyó Choquequirao?', '["Wari","Inca","Chachapoyas"]', 'Which culture built Choquequirao?', '["Wari","Inca","Chachapoyas"]', 'assets/modules/quiz/questions/pregunta5.png', 1);

-- Nivel 6
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('6', '¿Cuál es el material principal de construcción en Choquequirao?', '["Adobe","Piedra","Madera"]', 'What is the main building material at Choquequirao?', '["Adobe","Stone","Wood"]', 'assets/modules/quiz/questions/pregunta6.png', 1);

-- Nivel 7
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('7', '¿En qué siglo aproximado fue construido Choquequirao?', '["Siglo XII","Siglo XV","Siglo XVI"]', 'In approximately which century was Choquequirao built?', '["12th century","15th century","16th century"]', 'assets/modules/quiz/questions/pregunta7.png', 1);

-- Nivel 8
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('8', '¿Qué Inca mandó construir Choquequirao?', '["Pachacútec","Túpac Yupanqui","Huayna Cápac"]', 'Which Inca ordered the construction of Choquequirao?', '["Pachacutec","Tupac Yupanqui","Huayna Capac"]', 'assets/modules/quiz/questions/pregunta8.png', 0);

-- Nivel 9
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('9', '¿A qué altitud aproximada se encuentra Choquequirao?', '["2000 msnm","3000 msnm","4000 msnm"]', 'At approximately what altitude is Choquequirao located?', '["2000 masl","3000 masl","4000 masl"]', 'assets/modules/quiz/questions/pregunta9.png', 1);

-- Nivel 10
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('10', '¿Cómo se llama el río que bordea Choquequirao?', '["Urubamba","Apurímac","Amazonas"]', 'What is the name of the river bordering Choquequirao?', '["Urubamba","Apurímac","Amazon"]', 'assets/modules/quiz/questions/pregunta10.png', 1);

-- Nivel 11
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('11', '¿Cuántos días dura aproximadamente la ruta Cachora a Choquequirao (ida y vuelta)?', '["2 días","4-5 días","7 días"]', 'How many days does the Cachora to Choquequirao route approximately take (round trip)?', '["2 days","4-5 days","7 days"]', 'assets/modules/quiz/questions/pregunta11.png', 1);

-- Nivel 12
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('12', '¿Desde qué ciudad parte la ruta clásica a Choquequirao?', '["Lima","Cusco","Abancay"]', 'From which city does the classic route to Choquequirao depart?', '["Lima","Cusco","Abancay"]', 'assets/modules/quiz/questions/pregunta12.png', 1);

-- Nivel 13
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('13', '¿Cómo se llama la plaza principal de Choquequirao?', '["Plaza Hanan","Plaza principal","Sol de llamas"]', 'What is the main plaza of Choquequirao called?', '["Hanan plaza","Main plaza","Sun of llamas"]', 'assets/modules/quiz/questions/pregunta13.png', 1);

-- Nivel 14
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('14', '¿Qué representa el motivo de llamas en los muros de Choquequirao?', '["Llama","Serpiente","Cóndor"]', 'What does the llama motif on the walls of Choquequirao represent?', '["Llama","Snake","Condor"]', 'assets/modules/quiz/questions/pregunta14.png', 0);

-- Nivel 15
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('15', '¿En qué sector se encuentran los andenes con llamas?', '["Sector I","Sector II","Sector VIII"]', 'In which sector are the terraces with llamas found?', '["Sector I","Sector II","Sector VIII"]', 'assets/modules/quiz/questions/pregunta15.png', 2);

-- Nivel 16
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('16', '¿Para qué servían los Qollqas en Choquequirao?', '["Ceremonial","Vivienda","Almacén"]', 'What were the Qollqas at Choquequirao used for?', '["Ceremonial","Dwelling","Storage"]', 'assets/modules/quiz/questions/pregunta16.png', 2);

-- Nivel 17
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('17', '¿A qué civilización pertenece mayormente la arquitectura de Choquequirao?', '["Wari","Inca","Chachapoyas"]', 'To which civilization does the architecture of Choquequirao mainly belong?', '["Wari","Inca","Chachapoyas"]', 'assets/modules/quiz/questions/pregunta17.png', 1);

-- Nivel 18
INSERT INTO quiz_questions (QuizLevelId, QuestionText, Options, QuestionTextEn, OptionsEn, ImageUrl, CorrectOptionIndex) VALUES
('18', '¿Cuál es el material predominante en las construcciones de Choquequirao?', '["Adobe","Piedra","Madera"]', 'What is the predominant material in Choquequirao''s constructions?', '["Adobe","Stone","Wood"]', 'assets/modules/quiz/questions/pregunta18.png', 1);
