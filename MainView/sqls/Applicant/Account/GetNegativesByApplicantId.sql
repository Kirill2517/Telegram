SELECT Negatives_Guide.description from Applicant
INNER JOIN Applicant_Negatives on Applicant.idApplicant = Applicant_Negatives.idApplicant
INNER JOIN Negatives_Guide on idNegative = idNegatives
where Applicant.idApplicant = {0};