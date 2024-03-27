% � ���� ����� �������, ������, �������� � �������. ���� ��
% ��� ��������, ������ � ���������, ������ � ��������, ��������� �
% ��������, � ��� ��� ����� �� ������ ������ (� 1 �� 4). ��������, ���
% �� �������,�� �������� �� ����� ������ �� ����������� ������������.
% ������� �� �������� � ����� �� ������ �����. ��������, ������, �����
% ���� ����. �������� � �������� �� �������� ������� �� ���� � ������
% ����� �������. �������� ���������� �������� ����� � �������� �
% ��������. �������� ����� ���� ���������. ��������, ��� ���� ��� � ���
% �����.
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

    % �� �������,�� �������� �� ����� ������ �� ����������� ������������
    not(member((_, voronov, musician), List)),
    not(member((_, zhuravlev, musician), List)),

    % ������� �� �������� � ����� �� ������ �����
    not(member((_, voronov, artist), List)),
    member((1, voronov, _), List),

    % ��������, ������, ����� ���� ����
    member((4, _, artist), List),

    % �������� � �������� �� �������� ������� �� ���� � ������ ����� �������
    not(member((_, pavlov, artist), List)),
    not(member((_, pavlov, writer), List)),

    % �������� ���������� �������� ����� � �������� � ��������
    not(member((_, voronov, writer), List)),
    not(member((_, sinitsyn, writer), List)),


    % �������� ����� ���� ���������
    member((FloorZ, zhuravlev, _), List),
    member((FloorM, _, musician), List),
    FloorZ > FloorM.
