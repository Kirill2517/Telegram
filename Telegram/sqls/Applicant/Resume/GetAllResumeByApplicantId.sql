select Resume.idResume Id, 
		DataUser.email Owner, 
		Speciality.name Speciality, 
        workExperience, 
        desiredSalary, 
        description,
        Resume.created created,
        Resume.title
from Resume 
inner join Applicant on Applicant.idApplicant = Resume.idApplicant
inner join DataUser on Applicant.idApplicant = DataUser.id
inner join Speciality on Speciality.idSpeciality = Resume.idSpeciality
where Resume.idApplicant = {0};