% ���������� ������� � ���������� ������������.
% ������ ������������ ����� ���� ������� ����������: ���� ������������, ��� ������,
% ��� ����������, ������ ����������, ������ ������ - ����������. �������
% - ��������� ����� ���� ������� ��������� ����������: �������� �������,
% ������, ���������� ������������. ���������� ������������ ����� ����
% ������� ������� ��������: �������� ������� � ���������, ������, ���
% ���������� (�������, ��������, �����). ����������� ��������� ����
% ��������:
% 1 ����� ���, � ������� ����������� ������������ ����� ������, �
% �������� ����� ������������;
% 2 ����� ��� ������, � ������� ��������� �������� �������;
% 3 ����� ��� �������, ������� ����������� � ����������� ����� ��
% ������������� ���� ������;
% 4 ����� ��� �������, ������������� � ������������� � �������� ����;
% 5 ����� ��� ������� ������������ ������, � ������� ���� ��������.

% ���������� ��� ������ � http
:-use_module(library(http/http_server)).
:-use_module(library(http/http_dispatch)).
:-use_module(library(http/http_parameters)).
:-use_module(library(http/html_write)).

% ���������� ��� ������� ���������� ������
:- use_module(library(http/http_error)).

% ������� ��� �������� ��������
:- http_handler(root(.), home_page, []).

% ������� ��������� ��� ����� ������ ��� ������ ����, � ������������
% ������ ������
:- http_handler(root(max_teams_year_find), max_teams_year_find_page, []).
% ������� ������ ����, � ������� ������������ ������������ ����� �����
:- http_handler(root(max_teams_year), max_teams_year_page, [method(post)]).

% ������� ��������� ��� ����� ������ ��� ������ ���� ������, � �������
% ��������� �������� �������
:- http_handler(root(sport_by_team_find), sport_by_team_find_page, []).
% ������� ������ ���� ������, � ������� ��������� �������� �������
:- http_handler(root(sport_by_team), sport_by_team_page, [method(post)]).

% ������� ��������� ��� ����� ������ ��� ������ ���� ������, �������
% ������������ � ����������� ����� � ������������ ���� ������
:- http_handler(root(olympc_teams_by_sport_find), olympc_teams_by_sport_find_page, []).
% ������� ������ ���� ������, ������� ������������ � ���������� ����� �
% ������������ ���� ������
:- http_handler(root(olympc_teams_by_sport), olympc_teams_by_sport_page, [method(post)]).

% ������� ��������� ��� ����� ������ ��� ������ ���� ������, �������
% ������������ � �������� ����
:- http_handler(root(teams_in_year_find), teams_in_year_find_page, []).
% ������� ������ ���� ������, ������������� � ������������� � ��������
% ����
:- http_handler(root(teams_in_year), teams_in_year_page, [method(post)]).

% ������� ��������� ��� ����� ������ ��� ������ ���� ������ ������������
% ������, � ������� ���� ��������
:- http_handler(root(winning_teams_by_country_find), winning_teams_by_country_find_page, []).
% ������� ������ ���� ������ ������������ ������, � ������� ����
% ��������
:- http_handler(root(winning_teams_by_country), winning_teams_by_country_page, [method(post)]).

% ������� �������� ��� ���������� ������ ������������
:- http_handler(root(add), add_page, []).
% ������� ��� ���������� ������ ������������
:- http_handler(root(add_competition), add_competition, [method(post)]).

% ������� �������� ��� ��������� ���������� � ������������, �������
% ����� �������
:- http_handler(root(read), read_page, []).
% ������� ��� ��� ������ ����������
:- http_handler(root(read_competition), read_competition_page, [method(post)]).



% ������� �������� ��� �������� ������������
:- http_handler(root(delete), delete_page, []).
% ������� ��� �������� ������������
:- http_handler(root(delete_competition), delete_competition, [method(post)]).

% ������� �������� ��� ���������� ������������ ��� ����������
:- http_handler(root(update_find), update_find_page, []).
% ������� �������� ��� ��������� ������
:- http_handler(root(update), update_page, [method(post)]).
% ������� �������� ��� ��������� ������
:- http_handler(root(update_competition), update_competition, [method(post)]).


% ������� ��� ������ ��
:- http_handler(root(reset_DB), resetDB, [method(post)]).

% ����������� 5-�� ������� �������� � ��
:- dynamic competition/5.
:- dynamic team/3.
:- dynamic result/4.

% ������ �������
server(Port):- http_server(http_dispatch, [port(Port)]).
server:-server(8080).

% ��������� �������
stop(Port):- http_stop_server(Port, http_dispatch).
stop:- stop(8080).

resetDB(_):-
   % ������� ��
   retractall(competition(_, _, _, _, _)),
   retractall(team(_, _, _)),
   retractall(result(_, _, _, _)),

   % ������������� ��
    assertz(competition('����������� ����', '������ ��������', '2024', '�������',
            [team('������� ���', '���',
                  [result('������� ��������', '��������', '�������'),
                   result('������� ������', '������', '�������')]),
             team('������� ��������', '��������',
                  [result('������� ���', '���', '��������'),
                   result('������� ������', '������', '��������')]),
             team('������� ������', '������',
                  [result('������� ���', '���', '��������'),
                   result('������� ��������', '��������', '�������')])
            ])),

   assertz(competition('���������', '������', '2020', '������',
            [team('������� ������', '������',
                  [result('������� �������', '�������', '�������'),
                   result('������� �������', '�������', '��������')]),
            team('������� �������', '�������',
                  [result('������� ������', '������', '��������'),
                   result('������� �������', '�������', '��������')]),
            team('������� �������', '�������',
                  [result('������� ������', '������', '�������'),
                   result('������� �������', '�������', '�������')])
            ])),

   assertz(competition('���������', '���������', '2021', '���',
            [team('������� ���', '���',
                  [result('������� ������', '������', '�������'),
                   result('������� �������', '�������', '�������'),
                   result('������� �������', '�������', '��������')]),
            team('������� ������', '������',
                  [result('������� ���', '���', '��������'),
                   result('������� �������', '�������', '�����'),
                   result('������� �������', '�������', '�������')]),
            team('������� �������', '�������',
                  [result('������� ���', '���', '��������'),
                   result('������� ������', '������', '�����'),
                   result('������� �������', '�������', '�������')]),
            team('������� �������', '�������',
                  [result('������� ���', '���', '�������'),
                   result('������� ������', '������', '��������'),
                   result('������� �������', '�������', '��������')])
            ])),

   asserta(competition('��������� ����', '������', '2022', '������',
	[team('�����', '������',
              [result('�������', '������', '�������')]),
         team('�������', '������',
              [result('�����', '������', '��������')])
        ])),
/*
   asserta(competition('������', '��������', 2023, '��������',
            [team('���� �������', '��������',
                  [result('����� �������', '��������', '��������')]),
            team('����� �������', '��������',
                  [result('���� �������', '��������', '�������')])
            ])),*/

   assertz(competition('������', '��������', '2023', '��������',
            [team('���� �������', '��������',
                  [result('����� �������', '��������', '��������'),
                   result('���� �����', '��������', '�������')]),
            team('����� �������', '��������',
                  [result('���� �������', '��������', '�������'),
                   result('���� �����', '��������', '�����')]),
            team('���� �����', '��������',
                  [result('����� �������', '��������', '�����'),
                   result('���� �������', '��������', '��������')])
            ])),


   assertz(competition('����������� ����', '������', '2016', '���',
           [team('������� ���', '���',
                 [result('������� ������', '������', '��������')]),
           team('������� ������', '������',
                 [result('������� �����', '�����', '�������')]),
           team('������� �����', '�����',
                 [result('������� ������', '������', '��������')]),
           team('������� ������', '������',
                 [result('������� ���', '���', '�������')]),
           team('������� ����', '����',
                 [result('������� ������', '������', '�������')]),
           team('������� ������', '������',
                 [result('������� ����', '����', '��������')])
           ])),



   http_redirect(moved, '/', _Request).

% ��������� ������� ��������
home_page(_Request):-
    % ��������  ���� ������������ � ������
    findall(Rank, competition(Rank, _, _, _, _), Ranks),

    % ��������  ���� ������������ � ������
    findall(Sport, competition(_, Sport, _, _, _), Sports),

    % ��������  ���� ������������ � ������
    findall(Year, competition(_, _, Year, _, _), Years),

    % ��������  ���� ������������ � ������
    findall(Country, competition(_, _, _, Country, _), Countries),

    % ��������  ���� ������������ � ������
    %findall(Teams, competition(_, _, _, _, Teams), TeamsList),

    % ��������� ��������� �������
    generate_rows(Ranks, Sports, Years, Countries, Row),

    % ����������� ������
    flatten(Row, FlattenRow),

    ins(FlattenRow, tr(
                  [
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
            form(
                [style('display: inline-block'), method(post)],
                p(button([type(submit), formaction(location_by_id('resetDB'))], '�������� ��'))
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/add')], '�������� ������������'))
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/read')], '������� ������������'))
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/update_find')], '�������� ������������'))
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/delete')], '������� ������������'))
            ),

            h3('������� ������������'),
            table(
                [border(2)],
                Rows_with_Headers
            )
        ]).

% ���������� �������� � ������ ������
ins(L, El, [El|L]).

%generate_rows([], [], [], [], []).
%generate_rows([Rank|Ranks],
%              [Sport|Sports],
%              [Year|Years],
%              [Country|Countries],
%              [tr([td(Rank), td(Sport), td(Year), td(Country)])|Rows]):-
%    generate_rows(Ranks, Sports, Years, Countries, Rows).

generate_rows([], []).
generate_rows([Value|Values], [tr([td(Value)])|Rows]):-
    generate_rows(Values, Rows).

generate_rows([], [], [], [], []).
generate_rows([Rank|RestRanks],
              [Sport|RestSports],
              [Year|RestYears],
              [Country|RestCountries],
              [Rows|RestRows]):-

    % �������� ������ ������ ��� ������� Rank/Sport/Year/Country
    competition(Rank, Sport, Year, Country, TeamsList),

    % ���������� ������ ��� ������ ������� � �� �����������
    generate_team_rows(Rank, Sport, Year, Country, TeamsList, Rows),
    generate_rows(RestRanks, RestSports, RestYears, RestCountries, RestRows).



generate_team_rows(_, _, _, _,[], []).
generate_team_rows(Rank,
                   Sport,
                   Year,
                   Country,
                   [team(TeamName, TeamCountry, Results)|RestTeams], [TeamRow|RestRow]):-
        generate_result_rows(Rank, Sport, Year, Country, TeamName, TeamCountry, Results, TeamRow),
        %format(atom(Row), 'Team: ~w, Country: ~w', [TeamName, TeamCountry]),  % ������� ������ ������� �����
        %write(Row),  % ������� ������ ������� ����� � ������� ��� �������
        generate_team_rows(Rank, Sport, Year, Country, RestTeams, RestRow).

generate_result_rows(_, _, _, _, _, _, [], []).  % ������� ������ - ���������� ��������

generate_result_rows(Rank,
                     Sport,
                     Year,
                     Country,
                     TeamName,
                     TeamCountry,
                     [result(Opponent, OpponentCountry, Outcome)|RestResults],
                     [tr([td(Rank), td(Sport), td(Year), td(Country), td(TeamName), td(TeamCountry),
                          td(Opponent), td(OpponentCountry), td(Outcome)])|RestRows]):-
    %format(atom(Row), 'Match: ~w vs. ~w - ~w', [TeamName, Opponent, Outcome]),  % ������� ������ ������� �����
    %write(Row),  % ������� ������ ������� ����� � ������� ��� �������
    generate_result_rows(Rank, Sport, Year, Country, TeamName, TeamCountry, RestResults, RestRows).


% 1 ����� ���, � ������� ����������� ������������ ����� ������, �
% �������� ����� ������������;
maxTeamsYearList(Rank, YearRow) :-
    findall(NumTeams, (competition(Rank, _, Year, _, Teams),
                       length(Teams, NumTeams)), NumTeamsList),
    max_list(NumTeamsList, MaxNumTeams),
    findall(Year, (competition(Rank, _, Year, _, Teams),
                   length(Teams, MaxNumTeams)), YearList),
    generate_rows(YearList, YearRow).


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

max_teams_year_page(Request):-
   http_parameters(
        Request,
        [
            rank(Rank, [])
        ]
    ),
   maxTeamsYearList(Rank, YearRow),
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

% 2 ����� ��� ������, � ������� ��������� �������� �������;
sportByTeam(TeamName, SportsRow) :-
    %competition(_, Sport, _, _, Teams),
    %member(team(TeamName, _, _), Teams),
    findall(Sport, (competition(_, Sport, _, _, Teams),
                    member(team(TeamName, _, _), Teams)), Sports),
    generate_rows(Sports, SportsRow).

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
   sportByTeam(TeamName, SportRow),
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


% 3 ����� ��� �������, ������� ����������� � ����������� ����� ��
% ������������� ���� ������.
olympicTeamsBySport(Sport, TeamsRow) :-
    findall(Team,(competition('����������� ����', Sport, _, _, TeamsList),
                  member(team(Team, _, _), TeamsList)), Teams),
    generate_rows(Teams, TeamsRow).

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
   olympicTeamsBySport(Sport, TeamsRow),
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


% 4 ����� ��� �������, ������������� � ������������� � �������� ����;
teamsInYear(Year, TeamsRow) :-
   %atom_number(Year, YearNumber),
   findall(Team, (competition(_, _, Year, _, TeamsList),
                  member(team(Team, _, _), TeamsList)), Teams),
   generate_rows(Teams, TeamsRow).

teams_in_year_find_page(_Request):-
   reply_html_page(
        title('���� ����'),
        [form(
            [action=location_by_id(teams_in_year_page), method(post)],
            [
                h2('����� ��� �������, ������������� � ������������� � �������� ����'),
                table([
                    tr([th('���'), td(input([name(year), type(string)]))]),
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
   teamsInYear(Year, TeamsRow),
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


% 5 ����� ��� ������� ������������ ������, � ������� ���� ��������.
winningTeamsByCountry(Country, TeamsRow) :-
    findall(Team,
            (competition(_, _, _, _, TeamsList),
             member(team(Team, Country, Results), TeamsList),
             member(result(_, _, '�������'), Results)),
            Teams),
    list_to_set(Teams, UniqueTeams),
    generate_rows(UniqueTeams, TeamsRow).

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
   winningTeamsByCountry(Country, TeamsRow),
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

add_or_update_competition(Name, Sport, Year, Country, NewTeams) :-
    competition(Name, Sport, Year, Country, ExistingTeams),
    % ���� ������������ ��� ����������
    retract(competition(Name, Sport, Year, Country, ExistingTeams)),
    append(ExistingTeams, NewTeams, UpdatedTeams),
    asserta(competition(Name, Sport, Year, Country, UpdatedTeams)).

add_or_update_competition(Name, Sport, Year, Country, Teams) :-
    % ���� ������������ �� ����������, ��������� ����� ������������ � ���� ������
    asserta(competition(Name, Sport, Year, Country, Teams)).

% CRUD (Create/Read/Update/Delete)��� ����� ���� ������.
% C������� � ����������� ������ ������������
add_page(_Request):-
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
                    tr([th('�������'), td(input([name(teamName)]))]),
                    tr([th('������ �������'), td(input([name(teamCountry)]))]),
                    tr([th('������� ���������'), td(input([name(opponentName)]))]),
                    tr([th('������ ������� ���������'), td(input([name(opponentCountry)]))]),
                    tr([th('��������� ������������'), td(input([name(result)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='��������'])))
                ] )
            ]
        )]
    ).

% ��������, ������� ����� ��������� �������� � �������������� ��������
% ����������
check_and_replace(Result, NewResult) :-
    (Result = '�������' -> NewResult = '��������';
    Result = '��������' -> NewResult = '�������';
    NewResult = Result).

%���������� ������ ������������
add_competition(Request):-
    http_parameters(
        Request,
        [
            rank(Rank, []),
            sport(Sport, []),
            year(Year, []),
            country(Country, []),
            teamName(TeamName, []),
            teamCountry(TeamCountry, []),
            opponentName(OpponentName, []),
            opponentCountry(OpponentCountry, []),
            result(Result, [])
        ]
    ),
    check_and_replace(Result, NewResult),
    add_or_update_competition(Rank, Sport, Year, Country, [team(TeamName, TeamCountry, [result(OpponentName, OpponentCountry, Result)])]),
     add_or_update_competition(Rank, Sport, Year, Country, [team(OpponentName, OpponentCountry, [result(TeamName, TeamCountry, NewResult)])]),
    %assertz(competition(Rank, Sport, Year, Country, [
     %                                          team(TeamName, TeamCountry, [result(OpponentName, OpponentCountry, Result)]),
     %                                          team(OpponentName, OpponentCountry, [result(TeamName, TeamCountry, NewResult)])])),
    http_redirect(moved, '/', _Request).

read_page(_Request):-
    reply_html_page(
        title('������ ������������'),
        [form(
            [action=location_by_id(read_competition_page), method(post)],
            [
                table([
                    tr([th('����'), td(input([name(rank)]))]),
                    tr([th('��� ������'), td(input([name(sport)]))]),
                    tr([th('���'), td(input([name(year), type(number)]))]),
                    tr([th('������'), td(input([name(country)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='������'])))
                ] )
            ]
        )]
    ).

% ��������� ������� ��������
read_competition_page(Request):-
   http_parameters(
        Request,
        [
            rank(Rank, []),
            sport(Sport, []),
            year(Year, []),
            country(Country, [])
        ]
    ),
    % ��������� ��������� �������
    generate_rows([Rank], [Sport], [Year], [Country], Row),

    % ����������� ������
    flatten(Row, FlattenRow),

    ins(FlattenRow, tr(
                  [
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

            table(
                [border(2)],
                Rows_with_Headers
            )
        ]).

% C������� � ��������� ������������
delete_page(_Request):-
    reply_html_page(
        title('�������� ������������'),
        [form(
            [action=location_by_id(delete_competition), method(post)],
            [
                table([
                    tr([th('����'), td(input([name(rank)]))]),
                    tr([th('��� ������'), td(input([name(sport)]))]),
                    tr([th('���'), td(input([name(year), type(number)]))]),
                    tr([th('������'), td(input([name(country)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='�������'])))
                ] )
            ]
        )]
    ).

check_competition(Rank, Sport, Year, Country):-
   findall(Competition, competition(Rank, Sport, Year, Country, Competition), Competitions),
   length(Competitions, Length),
   Length \= 0 -> retractall(competition(Rank, Sport, Year, Country, _)).

% �������� ������������
delete_competition(Request):-
    http_parameters(
        Request,
        [
            rank(Rank, []),
            sport(Sport, []),
            year(Year, []),
            country(Country, [])
        ]
    ),
    %check_competition(Rank, Sport, Year, Country), % � ��� ��������
    retractall(competition(Rank, Sport, Year, Country, _)),
    http_redirect(moved, '/', Request).

% C������� ������ ������������ ��� ����������
update_find_page(_Request):-
    reply_html_page(
        title('����� ������������'),
        [form(
            [action=location_by_id(update_page), method(post)],
            [
                table([
                    tr([th('����'), td(input([name(rank)]))]),
                    tr([th('��� ������'), td(input([name(sport)]))]),
                    tr([th('���'), td(input([name(year), type(number)]))]),
                    tr([th('������'), td(input([name(country)]))]),
                    tr([th('�������'), td(input([name(teamName)]))]),
                    tr([th('������ �������'), td(input([name(teamCountry)]))]),
                    tr([th('������� ���������'), td(input([name(opponentName)]))]),
                    tr([th('������ ������� ���������'), td(input([name(opponentCountry)]))]),
                    tr([th('��������� ������������'), td(input([name(result)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='�����'])))
                ] )
            ]
        )]
    ).

% C������� ���������� ������
update_page(Request):-
   http_parameters(
        Request,
        [
            rank(Rank, []),
            sport(Sport, []),
            year(Year, []),
            country(Country, []),
            teamName(TeamName, []),
            teamCountry(TeamCountry, []),
            opponentName(OpponentName, []),
            opponentCountry(OpponentCountry, []),
            result(Result, [])
        ]
    ),
   reply_html_page(
        title('��������� ������������'),
        [form(
            [action=location_by_id(update_competition), method(post)],
            [
                table([
                    tr([th('�������'), td(input([name(teamName), value(TeamName)]))]),
                    tr([th('������ �������'), td(input([name(teamCountry), value(TeamCountry)]))]),
                    tr([th('������� ���������'), td(input([name(opponentName), value(OpponentName)]))]),
                    tr([th('������ ������� ���������'), td(input([name(opponentCountry), value(OpponentCountry)]))]),
                    tr([th('��������� ������������'), td(input([name(result), value(Result)]))]),

                    tr(td([colspan(2), align(right)], input([type=submit, value='��������']))),


                    tr([th(''), td(input([name(activTeamName), value(TeamName), type(hidden)]))]),
                    tr([th(''), td(input([name(activTeamCountry), value(TeamCountry), type(hidden)]))]),
                    tr([th(''), td(input([name(activOpponentName), value(OpponentName), type(hidden)]))]),
                    tr([th(''), td(input([name(activOpponentCountry), value(OpponentCountry), type(hidden)]))]),
                    tr([th(''), td(input([name(rank), value(Rank), type(hidden)]))]),
                    tr([th(''), td(input([name(sport), value(Sport), type(hidden)]))]),
                    tr([th(''), td(input([name(year), value(Year), type(hidden)]))]),
                    tr([th(''), td(input([name(country), value(Country), type(hidden)]))]),
                    tr([th(''), td(input([name(activResult), value(Result), type(hidden)]))])
                ] )
            ]
        )]
    ).

% �������� ��� �������� ������ � ���������� ����� ������
update_data(OldData, NewData):-
   retract(OldData),
   asserta(NewData).

% �������� ��� ���������� ������������
update_competition(Rank, Sport, Year, Country, OldTeams, NewTeams):-
   update_data(competition(Rank, Sport,Year, Country, OldTeams),
               competition(Rank, Sport,Year, Country, NewTeams)).

% �������� ��� ������ ������ � ������ � ������ ��������� ������ ����������
replace_teams([], _, _, []).
replace_teams([OldTeam|RestOldTeams], ChangedTeam, UpdateTeam, [ModifiedTeam|NewTeams]) :-
   % ���� ������� ������� ��������� � ��������, ������� ����� ��������
   OldTeam = team(OldTeamName, OldCountry, OldResults),
   ChangedTeam = team(ActivTeamName, ActivCountry, [result(ActivOpponentName, ActivOpponentCountry, ActivResult)]),
   UpdateTeam = team(UpdateTeamName, UpdateCountry, [result(UpdateOpponentName, UpdateOpponentCountry, UpdateResult)]),
   OldTeamName = ActivTeamName,  OldCountry = ActivCountry,

   modify_team_results(OldResults, result(ActivOpponentName, ActivOpponentCountry, ActivResult), result(UpdateOpponentName, UpdateOpponentCountry, UpdateResult), ModifiedResults),
   %format(atom(Row), 'Match: ~w vs. ~w ~n', [OldTeam, ChangedTeam]),  % ������� ������ ������� �����
   %write(Row),  % ������� ������ ������� ����� � ������� ��� �������
   ModifiedTeam = team(UpdateTeamName, UpdateCountry, ModifiedResults),
   % �������� ������ ���� ������� � ���������� �����������, ��������� �������� ��� ���������
   replace_teams(RestOldTeams, ChangedTeam, UpdateTeam, NewTeams).
replace_teams([OldTeam|RestOldTeams], ChangedTeam, UpdateTeam, [OldTeam|NewTeams]) :-
   %OldTeam = team(OldTeamName, OldCountry, _),
   %ChangedTeam = team(ActivTeamName, ActivCountry, _),
   %OldTeamName \== ActivTeamName, OldCountry \== ActivCountry,
   %format(atom(Row), 'Match: ~w vs. ~w ~n', [OldTeamName=ActivTeamName, OldCountry \= ActivCountry]),  % ������� ������ ������� �����
   %write(Row),  % ������� ������ ������� ����� � ������� ��� �������

   % ���� ������� ������� �� ��������� � �������� ��� ������, ��������� �� ��� ���������
   replace_teams(RestOldTeams, ChangedTeam, UpdateTeam, NewTeams).

% �������� ��� ����������� ����������� �������
modify_team_results([], _, _, []).
modify_team_results([OldResult|RestOldResults], ChangedResult, NewResult, [NewResult|ModifiedResults]) :-
    OldResult = ChangedResult,
    modify_team_results(RestOldResults, ChangedResult, NewResult, ModifiedResults).
modify_team_results([OldResult|RestOldResults], ChangedResult, NewResult, [OldResult|ModifiedResults]) :-
    OldResult \= ChangedResult,
    modify_team_results(RestOldResults, ChangedResult, NewResult, ModifiedResults).

% ���������� ������������
update_competition(Request):-
    http_parameters(
        Request,
        [
            rank(Rank, []),
            sport(Sport, []),
            year(Year, []),
            country(Country, []),
            teamName(TeamName, []),
            teamCountry(TeamCountry, []),
            opponentName(OpponentName, []),
            opponentCountry(OpponentCountry, []),
            result(Result, []),
            activTeamName(ActivTeamName, []),
            activTeamCountry(ActivTeamCountry, []),
            activOpponentName(ActivOpponentName, []),
            activOpponentCountry(ActivOpponentCountry, []),
            activResult(ActivResult, [])
        ]
    ),

    % �������� ������ �������� ������ � �� �� Rank/Sport/Year/Country, ���������� ������ ������ �� ����� ������ � ��������� ������������
    competition(Rank, Sport, Year, Country, ActivTeams),
    replace_teams(ActivTeams,
                  team(ActivTeamName, ActivTeamCountry,[result(ActivOpponentName, ActivOpponentCountry, ActivResult)]),
                  team(TeamName, TeamCountry, [result(OpponentName, OpponentCountry, Result)]),
                 NewTeams),
    update_competition(Rank, Sport, Year, Country, ActivTeams, NewTeams),

    % �������� ������ ����� ������ � �� �� Rank/Sport/Year/Country, �������� ���������� ������������ � ���������� ����������� �������� ��� ����
    competition(Rank, Sport, Year, Country, NewTeams),
    check_and_replace(Result, NewResult),
    check_and_replace(ActivResult, NewActivResult),
    replace_teams(NewTeams,
                  team(ActivOpponentName, ActivOpponentCountry,[result(ActivTeamName, ActivTeamCountry, NewActivResult)]),
                  team(OpponentName, OpponentCountry, [result(TeamName, TeamCountry, NewResult)]),
                 NewTeamsTwo),
    update_competition(Rank, Sport, Year, Country, NewTeams, NewTeamsTwo),


    http_redirect(moved, '/', _Request).
