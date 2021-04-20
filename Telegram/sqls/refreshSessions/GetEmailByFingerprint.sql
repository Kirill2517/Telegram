SELECT DataUser.email FROM refreshSessions
inner join DataUser on id = refreshSessions.idDataUser
where fingerprint = '{0}';