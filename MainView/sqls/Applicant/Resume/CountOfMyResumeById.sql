select count(*) count
from Resume 
inner join Applicant on Applicant.idApplicant = Resume.idApplicant
inner join DataUser on Applicant.idApplicant = DataUser.id
where Resume.idApplicant = {0};