select Sex_Guide.longName gender, Education.name education, Type_Of_Employment.name typeEmployment, Applicant.desiredWorkLocationArea desiredWorkLocationArea from Sex_Guide
	inner join Applicant on Sex_Guide.idSex = Applicant.idSex
	inner join Education on Applicant.idEducation = Education.idEducation
	inner join Type_Of_Employment on Applicant.idTypeOfDesiredEmployment = Type_Of_Employment.idType_Of_Employment
		where Applicant.idApplicant = {0};