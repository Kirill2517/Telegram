SELECT Positives_Guide.description from Applicant
INNER JOIN Applicant_Positives on Applicant.idApplicant = Applicant_Positives.idApplicant
INNER JOIN Positives_Guide on idPositive = idPositives
where Applicant.idApplicant = {0};