select Resume.idResume Id, 
		desiredSalary,
        created,
        title,
        Resume.description
        from Resume 
inner join Applicant on Applicant.idApplicant = Resume.idApplicant
inner join DataUser on Applicant.idApplicant = DataUser.id
inner join Speciality on Speciality.idSpeciality = Resume.idSpeciality
where DataUser.email = '{0}';