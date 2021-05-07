SELECT Positives_Guide.description from Resume
INNER JOIN Applicant on Applicant.idApplicant = Resume.idApplicant
INNER JOIN Applicant_Positives on Applicant_Positives.idApplicant = Applicant.idApplicant
INNER JOIN Positives_Guide on idPositives = idPositive
WHERE idResume = {0};