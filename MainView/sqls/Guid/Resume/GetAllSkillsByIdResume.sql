select Skills_Guide.description from Resume
inner join Skills_Resume on Resume.idResume = Skills_Resume.idResume
inner join Skills_Guide on Skills_Resume.idSkill = Skills_Guide.idSkill
where Resume.idResume = {0};