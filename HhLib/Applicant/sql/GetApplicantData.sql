select Sex_Guide.longName sexName, Education.name educationName, Type_Of_Employment.name typeName, Applicant.desiredWorkLocationArea location from Sex_Guide
	inner join Applicant on Sex_Guide.idSex = Applicant.idSex
	inner join Education on Applicant.idEducation = Education.idEducation
	inner join Type_Of_Employment on Applicant.idTypeOfDesiredEmployment = Type_Of_Employment.idType_Of_Employment
		where Applicant.idApplicant = 67