% ���������� ������� � ���������� ������������.
% ������ ������������ ����� ���� ������� ����������: ���� ������������, ��� ������,
% ��� ����������, ������ ����������, ������ ������ - ����������. �������
% - ��������� ����� ���� ������� ��������� ����������: �������� �������,
% ������, ���������� ������������. ���������� ������������ ����� ����
% ������� ������� ��������: �������� ������� � ���������, ������, ���
% ���������� (�������, ��������, �����). ����������� ��������� ����
% ��������:

% ���������� ��� ������ � ��
:- use_module(library(odbc)).

% ���������� ��� ������ � http
:-use_module(library(http/http_server)).
:-use_module(library(http/http_dispatch)).
:-use_module(library(http/http_parameters)).
:-use_module(library(http/html_write)).

% ���������� � ��
connect_db(Connection):-
    odbc_connect(
        'swi',
        Connection,
        [
            user(postgres),
            password(root),
            alias(dsn),
            open(once)
        ]
    ).

% ������� 1
% �� ������ 3 ������������ ������ ������� ���� ������ � ��������
% ���������� ������� � ���� ������. ������� ������ ����������� ���������
% ��������������� ���������.

%�������� ������
create_tables :-
    connect_db(_),
    odbc_query(
        dsn,
        'CREATE TABLE public.competition
        (
	  id SERIAL NOT NULL,
	  name TEXT NOT NULL,
	  type_sport TEXT NOT NULL,
	  year INTEGER NOT NULL,
	  country TEXT NOT NULL,
	  PRIMARY KEY (id)
         )'
    ),
    odbc_query(
        dsn,
        'CREATE TABLE public.team
        (
	  id SERIAL NOT NULL,
	  name TEXT NOT NULL,
	  country TEXT NOT NULL,
	  PRIMARY KEY (id)
         )'
    ),
    odbc_query(
        dsn,
        'CREATE TABLE public.result
        (
	  id SERIAL NOT NULL,
	  opponent_name TEXT NOT NULL,
	  country TEXT NOT NULL,
	  type_result TEXT NOT NULL,
	  PRIMARY KEY (id)
         )'
    ),
    odbc_query(
        dsn,
        'CREATE TABLE public.competition_team
        (
	  id SERIAL NOT NULL,
          competition_id INTEGER,
	  teams_id INTEGER,
	  result_id INTEGER,
	  PRIMARY KEY (id),
	  FOREIGN KEY (competition_id) REFERENCES competition (id),
	  FOREIGN KEY (teams_id) REFERENCES team (id),
	  FOREIGN KEY (result_id) REFERENCES result (id)
         )'
    ),
    odbc_disconnect(dsn).

% �������� ������
delete_tables:-
    connect_db(_),
    odbc_query(
        dsn,
        'DROP TABLE IF EXISTS public.competition, public.team, public.result, public.competition_team'
    ),
    odbc_disconnect(dsn).

% ������� ������ � ������� (��������)
insert_data_in_tables:-
     connect_db(_),
    odbc_query(
        dsn,
        'INSERT INTO competition (name, type_sport, year, country)
         VALUES
         (\'Olympic Games\', \'Athletics\', 2024, \'France\'),
         (\'Championship\', \'Football\', 2020, \'England\'),
         (\'Championship\', \'Basketball\', 2021, \'USA\'),
         (\'Friendly Match\', \'Football\', 2022, \'Russia\'),
         (\'Tournament\', \'Volleyball\', 2023, \'Brazil\'),
         (\'Olympic Games\', \'Wrestling\', 2016, \'USA\')'
    ),
    odbc_query(
        dsn,
        'INSERT INTO team (name, country)
        VALUES
        (\'USA National Team\', \'USA\'),
        (\'Germany National Team\', \'Germany\'),
        (\'Jamaica National Team\', \'Jamaica\'),
        (\'England National Team\', \'England\'),
        (\'France National Team\', \'France\'),
        (\'Spain National Team\', \'Spain\'),
        (\'Canada National Team\', \'Canada\'),
        (\'Mexico National Team\', \'Mexico\'),
        (\'Zenit\', \'Russia\'),
        (\'Spartak\', \'Russia\'),
        (\'Nova Serrana\', \'Brazil\'),
        (\'Ekip Jenkins\', \'Brazil\'),
        (\'Trez Volley\', \'Brazil\'),
        (\'USA Team\', \'USA\'),
        (\'Russia Team\', \'Russia\'),
        (\'Denmark Team\', \'Denmark\'),
        (\'Japan Team\', \'Japan\'),
        (\'Cuba Team\', \'Cuba\'),
        (\'Turkey Team\', \'Turkey\')'
    ),
    odbc_query(
        dsn,
        'INSERT INTO result (opponent_name, country, type_result)
        VALUES
        (\'Germany National Team\', \'Germany\', \'Win\'),
        (\'Jamaica National Team\', \'Jamaica\', \'Win\'),
        (\'USA National Team\', \'USA\', \'Loss\'),
        (\'Jamaica National Team\', \'Jamaica\', \'Loss\'),
        (\'USA National Team\', \'USA\', \'Loss\'),
        (\'Germany National Team\', \'Germany\', \'Win\'),
        (\'France National Team\', \'France\', \'Win\'),
        (\'Spain National Team\', \'Spain\', \'Loss\'),
        (\'England National Team\', \'England\', \'Loss\'),
        (\'Spain National Team\', \'Spain\', \'Loss\'),
        (\'England National Team\', \'England\', \'Win\'),
        (\'France National Team\', \'France\', \'Win\'),
        (\'Canada National Team\', \'Canada\', \'Win\'),
        (\'Mexico National Team\', \'Mexico\', \'Win\'),
        (\'France National Team\', \'France\', \'Loss\'),
        (\'USA National Team\', \'USA\', \'Loss\'),
        (\'Mexico National Team\', \'Mexico\', \'Draw\'),
        (\'France National Team\', \'France\', \'Win\'),
        (\'USA National Team\', \'USA\', \'Loss\'),
        (\'Canada National Team\', \'Canada\', \'Draw\'),
        (\'France National Team\', \'France\', \'Win\'),
        (\'USA National Team\', \'USA\', \'Win\'),
        (\'Canada National Team\', \'Canada\', \'Loss\'),
        (\'Mexico National Team\', \'Mexico\', \'Loss\'),
        (\'Spartak\', \'Russia\', \'Win\'),
        (\'Zenit\', \'Russia\', \'Loss\'),
        (\'Equipe Jenkins\', \'Brazil\', \'Loss\'),
        (\'Three Volley\', \'Brazil\', \'Win\'),
        (\'Nova Serrana\', \'Brazil\', \'Win\'),
        (\'Three Volley\', \'Brazil\', \'Draw\'),
        (\'Equipe Jenkins\', \'Brazil\', \'Draw\'),
        (\'Nova Serrana\', \'Brazil\', \'Loss\'),
        (\'Team Japan\', \'Japan\', \'Loss\'),
        (\'Team Denmark\', \'Denmark\', \'Win\'),
        (\'Team Russia\', \'Russia\', \'Loss\'),
        (\'Team USA\', \'USA\', \'Win\'),
        (\'Team Turkey\', \'Turkey\', \'Win\'),
        (\'Team Cuba\', \'Cuba\', \'Loss\')'
    ),
    odbc_query(
        dsn,
        'INSERT INTO competition_team (competition_id, teams_id, result_id)
        VALUES
        (1, 1, 1),
        (1, 1, 2),
        (1, 2, 3),
        (1, 2, 4),
        (1, 3, 5),
        (1, 3, 6),
        (2, 4, 7),
        (2, 4, 8),
        (2, 5, 9),
        (2, 5, 10),
        (2, 6, 11),
        (2, 6, 12),
        (3, 1, 13),
        (3, 1, 14),
        (3, 1, 15),
        (3, 7, 16),
        (3, 7, 17),
        (3, 7, 18),
        (3, 8, 19),
        (3, 8, 20),
        (3, 8, 21),
        (3, 5, 22),
        (3, 5, 23),
        (3, 5, 24),
        (4, 9, 25),
        (4, 10, 26),
        (5, 11, 27),
        (5, 11, 28),
        (5, 12, 29),
        (5, 12, 30),
        (5, 13, 31),
        (5, 13, 32),
        (6, 14, 33),
        (6, 15, 34),
        (6, 16, 35),
        (6, 17, 36),
        (6, 18, 37),
        (6, 19, 38)'
    ),
    odbc_disconnect(dsn).

%������� ������ � ������� competition
insert_competition(Name, TypeSport, Year, Country):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        "INSERT INTO public.competition (name, type_sport, year, country) VALUES (?, ?, ?, ?)",
        [varchar, varchar, integer, varchar],
        Statement
    ),
    odbc_execute(Statement, [Name, TypeSport, Year, Country]),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

%������� ������ � ������� team
insert_team(Name, Country):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'INSERT INTO public.team (name, country) VALUES (?, ?)',
        [varchar, varchar],
        Statement
    ),
    odbc_execute(Statement, [Name, Country]),
    %������� prepared statement � connection
    close_conn(Connection, Statement).


%������� ������ � ������� result
insert_result(OpponentName, Country, TypeResult):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'INSERT INTO result (opponent_name, country, type_result) VALUES (?, ?, ?)',
        [varchar, varchar, varchar],
        Statement
    ),
    odbc_execute(Statement, [OpponentName, Country, TypeResult]),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

%������� ������ � ������� competition_team
insert_competition_team(CompetitionId, TeamId, ResultId):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'INSERT INTO competition_team (competition_id, teams_id, result_id) VALUES (?, ?, ?)',
        [integer, integer, integer],
        Statement
    ),
    odbc_execute(Statement, [CompetitionId, TeamId, ResultId]),
    %������� prepared statement � connection
    close_conn(Connection, Statement).


% ������� 2
% ����������� ����� sql ��������, ��� ������ ������� ����� �����������
% ��� �������, ����������� � �������� ������� � ������������ 3.

% ������ ���� ����� � ����� ����� �� prepared statement
% ����������� ��������� processed_fetch_data � ������������� ��� ������
% ������ � ������
processed_fetch_data(Statement, Data) :-
    processed_fetch_data_acc(Statement, [], Data).

% ����������� ���������������� ��������� processedFetchDataAcc/3 � ������������� ��� ���������� ������
processed_fetch_data_acc(Statement, Acc, Result) :-
    odbc_fetch(Statement, Row, next),
    ( Row == end_of_file -> Result = Acc;  % ���� ��������� ����� �����, ���������� ��������� ������
       extract_data(Row, ExtractedData),
       append(Acc, [ExtractedData], NewAcc),  % ��������� ������ � ������
       processed_fetch_data_acc(Statement, NewAcc, Result)
    ).

% pattern matchin ��� ������ ���� ��� �������� ��������� ������
extract_data(row(Data), Data).
extract_data(row(Data_1, Data_2, Data_3), [Data_1, Data_2, Data_3]).
extract_data(row(Data_1, Data_2, Data_3, Data_4), [Data_1, Data_2, Data_3, Data_4]).
extract_data(row(Data_1, Data_2, Data_3, Data_4, Data_5), [Data_1, Data_2, Data_3, Data_4, Data_5]).
extract_data(row(Data_1, Data_2, Data_3, Data_4, Data_5, Data_6, Data_7, Data_8, Data_9, Data_10), [Data_1, Data_2, Data_3, Data_4, Data_5, Data_6, Data_7, Data_8, Data_9, Data_10]).

% 1 ����� ���, � ������� ����������� ������������ ����� ������, �
% �������� ����� ������������;
select_task_1(Rank, Data) :-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT max(subquery.year) as year
        FROM (
            SELECT competition.year as year, COUNT(DISTINCT team.name) AS num_teams
            FROM competition
            INNER JOIN competition_team ON competition.id = competition_team.competition_id
            INNER JOIN team ON competition_team.teams_id = team.id
            WHERE competition.name = (?)
            GROUP BY year
            ORDER BY num_teams DESC
        ) AS subquery',
        [varchar],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, [Rank]),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

% 2 ����� ��� ������, � ������� ��������� �������� �������;
select_task_2(TeamName, Data) :-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT DISTINCT competition.type_sport
        FROM competition
        INNER JOIN competition_team ON competition.id = competition_team.competition_id
        INNER JOIN team ON competition_team.teams_id = team.id
        WHERE team.name = (?)',
        [varchar],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, [TeamName]),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

% 3 ����� ��� �������, ������� ����������� � ����������� ����� ��
% ������������� ���� ������;
select_task_3(SportName, Data) :-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT DISTINCT team.name
        FROM team
        INNER JOIN competition_team ON team.id = competition_team.teams_id
        INNER JOIN competition ON competition_team.competition_id = competition.id
        WHERE competition.name = (?) and competition.type_sport = (?)',
        [varchar, varchar],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, ['Olympic Games', SportName]),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

% 4 ����� ��� �������, ������������� � ������������� � �������� ����;
select_task_4(Year, Data) :-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT DISTINCT team.name
        FROM team
        INNER JOIN competition_team ON competition_team.teams_id = team.id
        INNER JOIN competition ON competition_team.competition_id = competition.id
        WHERE competition.year = (?)',
        [integer],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, [Year]),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

% 5 ����� ��� ������� ������������ ������, � ������� ���� ��������.
select_task_5(Country, Data) :-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT DISTINCT team.name
        FROM team
        INNER JOIN competition_team ON competition_team.teams_id = team.id
        INNER JOIN competition ON competition_team.competition_id = competition.id
        INNER JOIN result ON competition_team.result_id = result.id
        WHERE result.type_result = (?) AND team.country = (?)',
        [varchar, varchar],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, ['Win', Country]),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

% ������� prepared statement � connection
close_conn(Connection, Statement):-
    odbc_free_statement(Statement),
    odbc_disconnect(Connection).

% ������� 3
% ��������� HTTP server libraries
% �������� CRUD (Create/Read/Update/Delete) ��� ���� ������ ���� ������.
% ������������ ������������ ����������� �������� ���� ������ � ���������
% (���������) �������� ����������.

% ������ �������
server(Port):- http_server(http_dispatch, [port(Port)]).
server:-server(8080).

% ��������� �������
stop(Port):- http_stop_server(Port, http_dispatch).
stop:- stop(8080).

% ������� ��� ������ ��
:- http_handler(root(reset_db), reset_db, [method(post)]).

% ����� �� �� ��������� ���������
reset_db(_):-
    delete_tables,
    create_tables,
    insert_data_in_tables,
    http_redirect(moved, '/', _Request).

create_competition(Name, TypeSport, Year, Country):-
    insert_competition(Name, TypeSport, Year, Country).

create_teams(Name, Country):-
    insert_team(Name, Country).

create_results(OpponentName, Country, TypeResult):-
    insert_result(OpponentName, Country, TypeResult).

create_competition_team(CompetitionId, TeamId, ResultId):-
    insert_competition_team(CompetitionId, TeamId, ResultId).

read_all(Data):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT competition_team.competition_id || \' \' || competition_team.teams_id
        || \' \' || competition_team.result_id as "id", competition.name as "����",
        competition.type_sport as "��� ������", competition.year as "��� ����������",
        competition.country as "������ ����������", team.name as "�������",
        team.country as "������ �������", result.opponent_name as "������� �������",
        result.country as "������ ���������", result.type_result as "���������"
        FROM competition
        INNER JOIN competition_team ON competition.id = competition_team.competition_id
        INNER JOIN team ON competition_team.teams_id = team.id
        INNER JOIN result ON competition_team.result_id = result.id',
        [],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, []),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

read_competition(Data):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT competition.id as "id", competition.name as "����",
        competition.type_sport as "��� ������", competition.year as "��� ����������",
        competition.country as "������ ����������"
        FROM competition',
        [],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, []),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

read_teams(Data):-
   connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT team.id as "id", team.name as "�������", team.country as "������ �������"
        FROM team',
        [],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, []),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

read_results(Data):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT result.id as "id", result.opponent_name as "������� �������",
        result.country as "������ ���������", result.type_result as "���������"
        FROM result',
        [],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, []),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

read_competition_team(Data):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'SELECT competition_team.competition_id AS "id ������������",
        competition_team.teams_id AS "id �������",
        competition_team.result_id AS "id ����������"
        FROM competition_team',
        [],
        Statement,
        [fetch(fetch)]
    ),
    odbc_execute(Statement, []),
    processed_fetch_data(Statement, Data),
    %������� prepared statement � connection
    close_conn(Connection, Statement).


update_competition(Id, Name, TypeSport, Year, Country):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'UPDATE competition
        SET name = (?), type_sport = (?), year = (?), country = (?)
        WHERE competition.id = (?)',
        [varchar, varchar, integer, varchar, integer],
        Statement
    ),
    odbc_execute(Statement, [Name, TypeSport, Year, Country, Id]),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

update_teams(Id, Name, Country):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'UPDATE team
        SET name = (?), country = (?)
        WHERE id = (?)',
        [varchar, varchar, integer],
        Statement
    ),
    odbc_execute(Statement, [Name, Country, Id]),
    %������� prepared statement � connection
    close_conn(Connection, Statement).

update_results(Id, OpponentName, Country, TypeResult):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'UPDATE result
        SET opponent_name = (?), country = (?), type_result = (?)
        WHERE id = (?)',
        [varchar, varchar, varchar, integer],
        Statement
    ),
    odbc_execute(Statement, [OpponentName, Country, TypeResult, Id]),
    %������� prepared statement � connection
    close_conn(Connection, Statement).


% ����� ��������� �����������
delete_competition(Id):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'UPDATE competition_team
        SET competition_id = NULL
        WHERE competition_id = (?);

        DELETE FROM competition
        WHERE id = (?)',
        [integer, integer],
        Statement
    ),
    odbc_execute(Statement, [Id, Id]),
    close_conn(Connection, Statement).

delete_teams(Id):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'UPDATE competition_team
        SET teams_id = NULL
        WHERE teams_id = (?);

        DELETE FROM team
        WHERE id = (?)
        ',
        [integer, integer],
        Statement
    ),
    odbc_execute(Statement, [Id, Id]),
    close_conn(Connection, Statement).


delete_results(Id):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'UPDATE competition_team
        SET result_id = NULL
        WHERE result_id = (?);

        DELETE FROM result
        WHERE id = (?)
        ',
        [integer, integer],
        Statement
    ),
    odbc_execute(Statement, [Id, Id]),
    close_conn(Connection, Statement).

delete_competition_team(CompetitionId, TeamId, ResultId):-
    connect_db(Connection),
    odbc_prepare(
        Connection,
        'DELETE FROM competition_team
          WHERE id =
          (
            SELECT id FROM competition_team
            WHERE competition_team.competition_id = (?) AND
	    competition_team.teams_id = (?) AND competition_team.result_id = (?)
         )',
        [integer, integer, integer],
        Statement
    ),
    odbc_execute(Statement, [CompetitionId, TeamId, ResultId]),
    close_conn(Connection, Statement).

% ������� 4 ����������� �����
% ����������� ���� ��������� �������� � ���� ������ �� html ���������.

% ������� ��� �������� ��������
:- http_handler(root(.), home_page, []).

% ������� ������: �������������� ������� ������� Data. Data - ������
% ��������
generate_rows([], []).

% ����������� ������: �������������� ������� Data � ������ Row
generate_rows([Data | Tail], [Row | Result]) :-
    generate_row(Data, Row),  % ��������� ������ Data � ������ Row
    generate_rows(Tail, Result).  % ����������� ����� ��� ���������� ���������

% �������� ��� �������������� ������� Data � ������ Row
generate_row(Data, Row) :-
    maplist(construct_td, Data, TdStrings),  % �������������� ������� �������� � ��� td
    Row = tr(TdStrings).

% �������� ��� �������� ���� td � �������
construct_td(Data, td(Data)).

% ���������� �������� � ������ ������
ins(L, El, [El|L]).

% ��������� ������� ��������
home_page(_Request):-
    read_all(Data),
    generate_rows(Data, Row),
    ins(Row, tr(
                  [
                    th('id'),
                    th('���� ������������'),
                    th('��� ������'),
                    th('���'),
                    th('������ ����������'),
                    th('�������'),
                    th('������'),
                    th('��������'),
                    th('������ ���������'),
                    th('���������')
                  ]
              ), Rows_with_Headers),

    reply_html_page(
        title('������� ���������� ������������'),
        [
            h1('���������� ������������'),

            h3('������� ��������'),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/max_teams_year_find')], 'Task_1'))
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/sport_by_team_find')], 'Task_2'))
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/olympc_teams_by_sport_find')], 'Task_3'))
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/teams_in_year_find')], 'Task_4'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/winning_teams_by_country_find')], 'Task_5'))
            ),

            br(''),

            h3('CRUD - CREAT/READ/UPDATE/DELETE'),
            h4('����� ���� ������ � ������������ ���������'),
            form(
                [style('display: inline-block'), method(post)],
                p(button([type(submit), formaction(location_by_id('reset_db'))], '�������� ��'))
            ),

            br(''),

            h4('���� ������ ������ �� ������'),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/read_competitions')], '���������� ������������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/read_teams')], '���������� �������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/read_results')], '���������� ����������'))
            ),

            br(''),

            h4('���� ���������� ������ � �������'),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/add_competition_fill')], '�������� ������������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/add_team_fill')], '�������� �������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/add_result_fill')], '�������� ���������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/add_competition_teams_fill')], '������� �������'))
            ),

            br(''),

            h4('���� ��������� ������ � ��������'),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/update_competition_find')], '�������� ������������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/update_team_find')], '�������� �������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/update_result_find')], '�������� ���������'))
            ),

            br(''),

            h4('���� �������� ������ � ��������'),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/delete_competition_find')], '������� ������������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/delete_team_find')], '������� �������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/delete_result_find')], '������� ���������'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/delete_full_data_find')], '������� �����'))
            ),

            h3('�������'),
            table(
                [border(2)],
                Rows_with_Headers
            )
        ]).

% ��� Task_1
% ������� ��������� ��� ����� ������ ��� ������ ����, � ������������
% ������ ������
:- http_handler(root(max_teams_year_find), max_teams_year_find_page, []).
% ������� ������ ����, � ������� ������������ ������������ ����� �����
:- http_handler(root(max_teams_year), max_teams_year_page, [method(post)]).

max_teams_year_find_page(_Request):-
   reply_html_page(
        title('���� ����� ������������'),
        [form(
            [action=location_by_id(max_teams_year_page), method(post)],
            [
                h2('����� ���, � ������� ����������� ������������ ����� ������, � �������� ����� ������������'),
                table([
                    tr([th('����'), td(input([name(rank)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='������'])))
                ] )
            ]
        )]
    ).

% Data - ������ ������� ������, �� �������� �����������, ������ �������
% - ����� ������
convert_to_row([], []).
convert_to_row([Data_head | Data_tail], [tr(td(Data_head)) | Row_tail]) :-
    convert_to_row(Data_tail, Row_tail).

max_teams_year_page(Request):-
   http_parameters(
        Request,
        [
            rank(Rank, [])
        ]
    ),
   select_task_1(Rank, Year),
   convert_to_row(Year, YearRow),
   ins(YearRow, tr(
                  [
                    th('���')
                  ]
              ), Rows_with_Headers),
    reply_html_page(
        title('���, � ������������ ������ ������'),
        [
            h1('���, � ������������ ������ ������'),
            table(
                [border(2)],
                Rows_with_Headers
            )
        ]
    ).

% ��� Task 2
% ������� ��������� ��� ����� ������ ��� ������ ���� ������, � �������
% ��������� �������� �������
:- http_handler(root(sport_by_team_find), sport_by_team_find_page, []).
% ������� ������ ���� ������, � ������� ��������� �������� �������
:- http_handler(root(sport_by_team), sport_by_team_page, [method(post)]).

sport_by_team_find_page(_Request):-
   reply_html_page(
        title('���� �������� �������'),
        [form(
            [action=location_by_id(sport_by_team_page), method(post)],
            [
                h2('����� ��� ������, � ������� ��������� �������� �������'),
                table([
                    tr([th('�������� �������'), td(input([name(teamName)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='������'])))
                ] )
            ]
        )]
    ).

sport_by_team_page(Request):-
   http_parameters(
        Request,
        [
            teamName(TeamName, [])
        ]
    ),
   select_task_2(TeamName, TypeSport),
   convert_to_row(TypeSport, SportRow),
   ins(SportRow, tr(
                  [
                    th('��� ������')
                  ]
              ), Rows_with_Headers),
    reply_html_page(
        title('��� ������, � ������� ��������� �������� �������'),
        [
            h1('��� ������, � ������� ��������� �������� �������'),
            table(
                [border(2)],
                Rows_with_Headers
            )
        ]
    ).

% ��� Task 3
% ������� ��������� ��� ����� ������ ��� ������ ���� ������, �������
% ������������ � ����������� ����� � ������������ ���� ������
:- http_handler(root(olympc_teams_by_sport_find), olympc_teams_by_sport_find_page, []).
% ������� ������ ���� ������, ������� ������������ � ���������� ����� �
% ������������ ���� ������
:- http_handler(root(olympc_teams_by_sport), olympc_teams_by_sport_page, [method(post)]).

olympc_teams_by_sport_find_page(_Request):-
   reply_html_page(
        title('���� �������� ������'),
        [form(
            [action=location_by_id(olympc_teams_by_sport_page), method(post)],
            [
                h2('����� ��� �������, ������� ����������� � ����������� ����� �� ������������� ���� ������'),
                table([
                    tr([th('�������� ���� ������'), td(input([name(sport)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='������'])))
                ] )
            ]
        )]
    ).

olympc_teams_by_sport_page(Request):-
   http_parameters(
        Request,
        [
            sport(Sport, [])
        ]
    ),
   select_task_3(Sport, Teams),
   convert_to_row(Teams, TeamsRow),
   ins(TeamsRow, tr(
                  [
                    th('�������� �������')
                  ]
              ), Rows_with_Headers),
    reply_html_page(
        title('�������, ����������� � ����������� ����� � ������������ ���� ������'),
        [
            h1('�������, ������� ����������� � ����������� ����� � ������������ ���� ������'),
            table(
                [border(2)],
                Rows_with_Headers
            )
        ]
    ).

% ��� Task 4
% ������� ��������� ��� ����� ������ ��� ������ ���� ������, �������
% ������������ � �������� ����
:- http_handler(root(teams_in_year_find), teams_in_year_find_page, []).
% ������� ������ ���� ������, ������������� � ������������� � ��������
% ����
:- http_handler(root(teams_in_year), teams_in_year_page, [method(post)]).

teams_in_year_find_page(_Request):-
   reply_html_page(
        title('���� ����'),
        [form(
            [action=location_by_id(teams_in_year_page), method(post)],
            [
                h2('����� ��� �������, ������������� � ������������� � �������� ����'),
                table([
                    tr([th('���'), td(input([name(year), type(number)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='������'])))
                ] )
            ]
        )]
    ).

teams_in_year_page(Request):-
   http_parameters(
        Request,
        [
            year(Year, [])
        ]
    ),
   atom_number(Year, Number),
   select_task_4(Number, Teams),
   convert_to_row(Teams, TeamsRow),
   ins(TeamsRow, tr(
                  [
                    th('�������� �������')
                  ]
              ), Rows_with_Headers),
    reply_html_page(
        title('�������, ������������� � ������������� � �������� ����'),
        [
            h1('�������, ������������� � ������������� � �������� ����'),
            table(
                [border(2)],
                Rows_with_Headers
            )
        ]
    ).

% ��� Task 5
% ������� ��������� ��� ����� ������ ��� ������ ���� ������ ������������
% ������, � ������� ���� ��������
:- http_handler(root(winning_teams_by_country_find), winning_teams_by_country_find_page, []).

% ������� ������ ���� ������ ������������ ������, � ������� ����
% ��������
:- http_handler(root(winning_teams_by_country), winning_teams_by_country_page, [method(post)]).

winning_teams_by_country_find_page(_Request):-
   reply_html_page(
        title('���� ������'),
        [form(
            [action=location_by_id(winning_teams_by_country_page), method(post)],
            [
                h2('����� ��� ������� ������������ ������, � ������� ���� ��������'),
                table([
                    tr([th('������'), td(input([name(country)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='������'])))
                ] )
            ]
        )]
    ).

winning_teams_by_country_page(Request):-
   http_parameters(
        Request,
        [
            country(Country, [])
        ]
    ),
   select_task_5(Country, Teams),
   convert_to_row(Teams, TeamsRow),
   ins(TeamsRow, tr(
                  [
                    th('�������� �������')
                  ]
              ), Rows_with_Headers),
    reply_html_page(
        title('������� ������������ ������, � ������� ���� ��������'),
        [
            h1('������� ������������ ������, � ������� ���� ��������'),
            table(
                [border(2)],
                Rows_with_Headers
            )
        ]
    ).

% ���������� ��������� ��������� ������
% ������ ��� ��������� � ����������� � ���������� �������������
:- http_handler(root(read_competitions), read_competition_page, []).

read_competition_page(_Request):-
    % ��������� ��������� �������
    read_competition(Data),
    generate_rows(Data, Row),

    ins(Row, tr(
                  [
                    th('id'),
                    th('���� ������������'),
                    th('��� ������'),
                    th('���'),
                    th('������ ����������')                  ]
              ), Rows_with_Headers),

    reply_html_page(
        title('������� ���������� ������������'),
        [
            h1('���������� ������������'),

            table(
                [border(2)],
                Rows_with_Headers
            )
        ]).

% ������ ��� ��������� � ����������� � ���������� ��������
:- http_handler(root(read_teams), read_teams_page, []).

read_teams_page(_Request):-
    % ��������� ��������� �������
    read_teams(Data),
    generate_rows(Data, Row),

    ins(Row, tr(
                  [
                    th('id'),
                    th('�������� �������'),
                    th('������ �������')                ]
              ), Rows_with_Headers),

    reply_html_page(
        title('������� ���������� ������'),
        [
            h1('�������'),

            table(
                [border(2)],
                Rows_with_Headers
            )
        ]).

% ������ ��� ��������� � ����������� � ����������� ������������
:- http_handler(root(read_results), read_results_page, []).


read_results_page(_Request):-
    % ��������� ��������� �������
    read_results(Data),
    generate_rows(Data, Row),

    ins(Row, tr(
                  [
                    th('id'),
                    th('�������� ������� ���������'),
                    th('������ ������� ���������'),
                    th('���������')
             ]
              ), Rows_with_Headers),

    reply_html_page(
        title('������� ����������� ������������'),
        [
            h1('����������'),

            table(
                [border(2)],
                Rows_with_Headers
            )
        ]).

% ���������� ��������� ��� ���������� ������ � �������
% ������� �������� ��� ���������� ������ ������������
:- http_handler(root(add_competition_fill), add_competition_fill_page, []).
% ������� ��� ���������� ������ ������������
:- http_handler(root(add_competition), add_competition, [method(post)]).

% ������������
add_competition_fill_page(_Request):-
    reply_html_page(
        title('���������� ������������'),
        [form(
            [action=location_by_id(add_competition), method(post)],
            [
                table([
                    tr([th('����'), td(input([name(rank)]))]),
                    tr([th('��� ������'), td(input([name(sport)]))]),
                    tr([th('���'), td(input([name(year), type(number)]))]),
                    tr([th('������'), td(input([name(country)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

add_competition(Request):-
    http_parameters(
        Request,
        [
            rank(Rank, []),
            sport(Sport, []),
            year(Year, []),
            country(Country, [])
        ]
    ),
    atom_number(Year, Number),
    create_competition(Rank, Sport, Number, Country),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� ���������� ����� �������
:- http_handler(root(add_team_fill), add_team_fill_page, []).
% ������� ��� ���������� ������ ������������
:- http_handler(root(add_team), add_team, [method(post)]).

% �������
add_team_fill_page(_Request):-
    reply_html_page(
        title('���������� �������'),
        [form(
            [action=location_by_id(add_team), method(post)],
            [
                table([
                    tr([th('�������� �������'), td(input([name(team)]))]),
                    tr([th('������ �������'), td(input([name(country)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

add_team(Request):-
    http_parameters(
        Request,
        [
            team(TeamName, []),
            country(Country, [])
        ]
    ),
    create_teams(TeamName, Country),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� ���������� ���������� ������������
:- http_handler(root(add_result_fill), add_result_fill_page, []).
% ������� ��� ���������� ������ ������������
:- http_handler(root(add_result), add_result, [method(post)]).


% ����������
add_result_fill_page(_Request):-
    reply_html_page(
        title('���������� ����������'),
        [form(
            [action=location_by_id(add_result), method(post)],
            [
                table([
                    tr([th('�������� ������� ���������'), td(input([name(team)]))]),
                    tr([th('������ ������� ���������'), td(input([name(country)]))]),
                    tr([th('���������'), td(input([name(result)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

add_result(Request):-
    http_parameters(
        Request,
        [
            team(TeamName, []),
            country(Country, []),
            result(Result, [])
        ]
    ),
    create_results(TeamName, Country, Result),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� ���������� id-������ ��� ��������� �������
:- http_handler(root(add_competition_teams_fill), add_competition_teams_fill_page, []).
% ������� ��� ���������� ������ ������������
:- http_handler(root(add_competition_teams), add_competition_teams, [method(post)]).

% ��������� �������
add_competition_teams_fill_page(_Request):-
    reply_html_page(
        title('���������� id-������ ��� ��������� �������'),
        [form(
            [action=location_by_id(add_competition_teams), method(post)],
            [
                table([
                    tr([th('id ������������'), td(input([name(competition), type(number)]))]),
                    tr([th('id �������'), td(input([name(team), type(number)]))]),
                    tr([th('id ����������'), td(input([name(result), type(number)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

add_competition_teams(Request):-
    http_parameters(
        Request,
        [
            competition(CompetitionId, []),
            team(TeamId, []),
            result(ResultId, [])
        ]
    ),
    atom_number(CompetitionId, NCompetitionId),
    atom_number(TeamId, NTeamId),
    atom_number(ResultId, NResultId),
    create_competition_team(NCompetitionId, NTeamId, NResultId),
    http_redirect(moved, '/', _Request).

% ���������� ��������� ��� ��������� ������ � ��������
% ������� �������� ��� ���������� ������ � ������� ������������
:- http_handler(root(update_competition_find), update_competition_find_page, []).
% ������� ��� ���������� ������������
:- http_handler(root(update_competition), update_competition, [method(post)]).

update_competition_find_page(_Request):-
    reply_html_page(
        title('��������� ������ � ������� ������������'),
        [form(
            [action=location_by_id(update_competition), method(post)],
            [
                table([
                    tr([th('id ������������'), td(input([name(id), type(number)]))]),
                    tr([th('���� ������������'), td(input([name(rank)]))]),
                    tr([th('��� ������'), td(input([name(sport)]))]),
                    tr([th('��� ����������'), td(input([name(year), type(number)]))]),
                    tr([th('������ ����������'), td(input([name(country)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

update_competition(Request):-
    http_parameters(
        Request,
        [
            id(CompetitionId, []),
            rank(Rank, []),
            sport(TypeSport, []),
            year(Year, []),
            country(Country, [])
        ]
    ),
    atom_number(CompetitionId, NCompetitionId),
    atom_number(Year, NYear),
    update_competition(NCompetitionId, Rank, TypeSport, NYear, Country),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� ���������� �������
:- http_handler(root(update_team_find), update_team_find_page, []).
% ������� ��� ���������� �������
:- http_handler(root(update_team), update_team, [method(post)]).

update_team_find_page(_Request):-
    reply_html_page(
        title('��������� ������ � ������� ������'),
        [form(
            [action=location_by_id(update_team), method(post)],
            [
                table([
                    tr([th('id �������'), td(input([name(id), type(number)]))]),
                    tr([th('�������� �������'), td(input([name(name)]))]),
                    tr([th('������ �������'), td(input([name(country)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

update_team(Request):-
    http_parameters(
        Request,
        [
            id(TeamId, []),
            name(TeamName, []),
            country(Country, [])
        ]
    ),
    atom_number(TeamId, NTeamId),
    update_teams(NTeamId, TeamName, Country),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� ���������� ����������
:- http_handler(root(update_result_find), update_result_find_page, []).
% ������� ��� ���������� ����������
:- http_handler(root(update_result), update_result, [method(post)]).


update_result_find_page(_Request):-
    reply_html_page(
        title('��������� ������ � ������� �����������'),
        [form(
            [action=location_by_id(update_result), method(post)],
            [
                table([
                    tr([th('id ����������'), td(input([name(id), type(number)]))]),
                    tr([th('�������� ������� ���������'), td(input([name(name)]))]),
                    tr([th('������ ���������'), td(input([name(country)]))]),
                    tr([th('���������'), td(input([name(result)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

update_result(Request):-
    http_parameters(
        Request,
        [
            id(ResultId, []),
            name(OpponentName, []),
            country(OpponentCountry, []),
            result(Result, [])
        ]
    ),
    atom_number(ResultId, NResultId),
    update_results(NResultId, OpponentName, OpponentCountry, Result),
    http_redirect(moved, '/', _Request).

% ���������� ��������� ��� �������� ������ � ��������
% ������� �������� ��� ������� �������� ��������� ������
:- http_handler(root(delete_full_data_find), delete_full_date_find_page, []).
% ������� ��� ������� �������� ��������� ������
:- http_handler(root(delete_full_data), delete_full_data, [method(post)]).

delete_full_date_find_page(_Request):-
    reply_html_page(
        title('��������� id-������ ��� ��������� �������'),
        [form(
            [action=location_by_id(delete_full_data), method(post)],
            [
                table([
                    tr([th('id ������������'), td(input([name(competition), type(number)]))]),
                    tr([th('id �������'), td(input([name(team), type(number)]))]),
                    tr([th('id ����������'), td(input([name(result), type(number)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='�������'])))
                ] )
            ]
        )]
    ).

delete_full_data(Request):-
    http_parameters(
        Request,
        [
            competition(CompetitionId, []),
            team(TeamId, []),
            result(ResultId, [])
        ]
    ),
    atom_number(CompetitionId, NCompetitionId),
    atom_number(TeamId, NTeamId),
    atom_number(ResultId, NResultId),
    delete_competition_team(NCompetitionId, NTeamId, NResultId),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� �������� ������ �� ������������
:- http_handler(root(delete_competition_find), delete_competition_find_page, []).
% ������� ��� �������� ������ �� ������������
:- http_handler(root(delete_competition), delete_competition_method, [method(post)]).


delete_competition_find_page(_Request):-
    reply_html_page(
        title('�������� ������ � ������� ������������'),
        [form(
            [action=location_by_id(delete_competition_method), method(post)],
            [
                table([
                    tr([th('id ������������'), td(input([name(id), type(number)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='�������'])))
                ] )
            ]
        )]
    ).

delete_competition_method(Request):-
    http_parameters(
        Request,
        [
            id(CompetitionId, [])
        ]
    ),
    atom_number(CompetitionId, NCompetitionId),
    delete_competition(NCompetitionId),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� �������� ������ �� ������
:- http_handler(root(delete_team_find), delete_team_find_page, []).
% ������� ��� �������� ������
:- http_handler(root(delete_team), delete_team_method, [method(post)]).


delete_team_find_page(_Request):-
    reply_html_page(
        title('�������� ������ �� ������� ������'),
        [form(
            [action=location_by_id(delete_team_method), method(post)],
            [
                table([
                    tr([th('id �������'), td(input([name(id), type(number)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='�������'])))
                ] )
            ]
        )]
    ).

delete_team_method(Request):-
    http_parameters(
        Request,
        [
            id(TeamId, [])
        ]
    ),
    atom_number(TeamId, NTeamId),
    delete_teams(NTeamId),
    http_redirect(moved, '/', _Request).

% ������� �������� ��� �������� ������ �� ������� �����������
:- http_handler(root(delete_result_find), delete_result_find_page, []).
% ������� ��� �������� �����������
:- http_handler(root(delete_result), delete_result_method, [method(post)]).


delete_result_find_page(_Request):-
    reply_html_page(
        title('�������� ������ �� ������� �����������'),
        [form(
            [action=location_by_id(delete_result_method), method(post)],
            [
                table([
                    tr([th('id ����������'), td(input([name(id), type(number)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='�������'])))
                ] )
            ]
        )]
    ).

delete_result_method(Request):-
    http_parameters(
        Request,
        [
            id(ResultId, [])        ]
    ),
    atom_number(ResultId, NResultId),
    delete_results(NResultId),
    http_redirect(moved, '/', _Request).










