% В доме живут Воронов, Павлов, Журавлев и Синицын. Один из
% них художник, другой – математик, третий – писатель, четвертый –
% музыкант, и все они живут на разных этажах (с 1 по 4). Известно, что
% ни Воронов,ни Журавлев не умеют играть на музыкальных инструментах.
% Воронов не художник и живет на первом этаже. Художник, кстати, живет
% выше всех. Писатель и художник по выходным уезжают на дачу к своему
% другу Павлову. Писатель собирается написать очерк о Синицыне и
% Воронове. Журавлев живет выше музыканта. Выяснить, кто есть кто и где
% живет.
%
solve(List):-
        List = [
        (_, voronov, _),
        (_, pavlov, _),
        (_, zhuravlev, _),
        (_, sinitsyn, _)
    ],

    member((_,_, artist), List),
    member((_,_, mathematician), List),
    member((_,_, writer), List),
    member((_,_, musician), List),

    member((1,_, _), List),
    member((2,_, _), List),
    member((3,_, _), List),
    member((4,_, _), List),

    % Ни Воронов,ни Журавлев не умеют играть на музыкальных инструментах
    not(member((_, voronov, musician), List)),
    not(member((_, zhuravlev, musician), List)),

    % Воронов не художник и живет на первом этаже
    not(member((_, voronov, artist), List)),
    member((1, voronov, _), List),

    % Художник, кстати, живет выше всех
    member((4, _, artist), List),

    % Писатель и художник по выходным уезжают на дачу к своему другу Павлову
    not(member((_, pavlov, artist), List)),
    not(member((_, pavlov, writer), List)),

    % Писатель собирается написать очерк о Синицыне и Воронове
    not(member((_, voronov, writer), List)),
    not(member((_, sinitsyn, writer), List)),


    % Журавлев живет выше музыканта
    member((FloorZ, zhuravlev, _), List),
    member((FloorM, _, musician), List),
    FloorZ > FloorM.
