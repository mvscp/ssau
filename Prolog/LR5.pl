% ����������� n �������� ������, ������� � i-��� �������. ���� n ��
% �������, �������� ������ �� �����.

app(SubString):-
    write('������� ������: '),
    read_string(user_input, '\n', '\r', _, String),
    write('������� i: '),
    read_string(user_input, '\n', '\r', _, SIndex),
    number_string(Index, SIndex),
    write('������ ���-�� �������� ��� �����������? y/n: '),
    read_string(user_input, '\n', '\r', _, Choice),
    atom_string(Symbol, Choice),
    (
        Symbol == 'y' ->
        write('������� ���������� �������� ��� �����������: '),
        read_string(user_input, '\n', '\r', _, SNumber),
        number_string(Number, SNumber),
        write(''),
        copy_symbols(String, Index, Number, SubString);
        copy_symbols(String, Index, SubString)
    ).

validator(StartIndex, LastIndex, Number):-
    StartIndex >= 0,
    StartIndex =< LastIndex,
    Number >= 0.

% �������� ��� ����������� n �������� �� ������ ������� � i-�� �������
copy_symbols(String, StartIndex, Number, SubString) :-
    string_length(String, Length),
    LastIndex is Length - 1,
    (
      String == "" ->
      % ������� ������: ���� ������ ������, ���������� ������ ���������
      SubString = "";
      % �������� ��������� ������ ��� StartIndex, LastIndex, Number
      validator(StartIndex, LastIndex, Number),
      AcceptNumber is LastIndex - StartIndex + 1,
      (
        % ���������, ��������� �� Number ���������� �������� AcceptNumber
        Number > AcceptNumber ->
        sub_string(String, StartIndex, AcceptNumber, _, SubString);
        sub_string(String, StartIndex, Number, _, SubString)
      )
    ).

% �������� ��� ����������� ���� �������� �� ������ ������� � i-��
% �������
copy_symbols(String, StartIndex, SubString):-
    string_length(String, Length),
    LastIndex is Length - 1,
    Number is LastIndex - StartIndex + 1,
    copy_symbols(String, StartIndex, Number, SubString).

% ���� ����� ��� ��������� copy_symbols
% run_tests
%:-use_module(plunit).
:-begin_tests(copy_symbols).
test(empty_string, [true(Result="")]):-
    copy_symbols("", 0, 0, Result).

test(all_symbols, [true(Result="hello")]):-
    copy_symbols("hello", 0, 5, Result).

test(start_index_0, [true(Result="hel")]):-
    copy_symbols("hello", 0, 3, Result).

test(start_index_not_zero, [true(Result="llo")]):-
    copy_symbols("hello", 2, 3, Result).

test(number_less_than_to_copy, [true(Result="he")]):-
    copy_symbols("hello", 0, 2, Result).

test(number_greater_than_to_copy, [true(Result="hello")]):-
    copy_symbols("hello", 0, 10, Result).

test(invalid_start_index_less_than_zero, [fail]):-
    copy_symbols("hello", -1, 3, _).

test(invalid_start_index_great_than_length, [fail]):-
    copy_symbols("hello", 10, 3, _).

test(invalid_number, [fail]):-
    copy_symbols("hello", 0, -3, _).
