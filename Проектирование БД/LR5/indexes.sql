CREATE FULLTEXT INDEX profile_index ON artist(PROFILE);
CREATE FULLTEXT INDEX real_name_index ON artist(REALNAME);
CREATE INDEX group_name_index ON artist(NAME);