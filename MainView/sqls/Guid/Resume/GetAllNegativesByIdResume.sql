SELECT Negatives_Guide.description from Resume
INNER JOIN Applicant on Applicant.idApplicant = Resume.idApplicant
INNER JOIN Applicant_Negatives on Applicant_Negatives.idApplicant = Applicant.idApplicant
INNER JOIN Negatives_Guide on idNegatives = idNegative
WHERE idResume = {0};