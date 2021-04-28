select Vacancy.idVacancy Id, DataUser.email Owner, Posts.name Post, Speciality.name Speciality, Type_Of_Employment.name typeEmployment, Vacancy.salary, Vacancy.workingPeriod, Vacancy.title, Vacancy.description, Vacancy.created from Vacancy
inner join Employer on Employer.idEmployer = Vacancy.idEmployer
inner join Posts on Posts.idPost = Vacancy.idPost
inner join Speciality on Speciality.idSpeciality = Vacancy.idSpeciality
inner join Type_Of_Employment on Type_Of_Employment.idType_Of_Employment = Vacancy.idTypeOfEmployment
inner join DataUser on DataUser.id = Employer.idEmployer
where idVacancy = {0};