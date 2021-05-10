select Resume.idResume Id
from Resume 
inner join Applicant on Applicant.idApplicant = Resume.idApplicant
inner join DataUser on Applicant.idApplicant = DataUser.id
where DataUser.email = '{0}'
#1 - номер строки-начала
#2 - количество записей
limit {1}, {2};