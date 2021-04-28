SELECT Skills_Guide.description from Vacancy
INNER JOIN Skills_Vacancy on Skills_Vacancy.idVacancy = Vacancy.idVacancy
INNER JOIN Skills_Guide on Skills_Guide.idSkill = Skills_Vacancy.idSkill
WHERE Vacancy.idVacancy = {0};