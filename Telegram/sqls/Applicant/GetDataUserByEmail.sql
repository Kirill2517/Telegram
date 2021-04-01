SELECT DataUser.* FROM Applicant 
	inner join DataUser on Applicant.idApplicant = DataUser.id 
where Applicant.idApplicant = {0};