:-use_module(library(pce)).

create_gui:-
    new(D, dialog('Вставка элемента в список')),
	send(D, append, new(List, text_item('Список:'))),
	send(D, append, new(Position, int_item('Позиция:', low:=0))),
	send(D, append, new(Element, text_item('Элемент:'))),
	send(D, append, button('Вставить', message(@prolog, insert_element, Position?selection, Element?selection, List?selection))),
	send(D, open).

insert_element(Position, Element, List):-
    atom_codes(List, Codes),
    read_from_codes(Codes, L),
    insert_in(Element, Position, L, Result),
    send_result(Result).
    /*format('Вставить элемент на позицию ~d: ~w~n', [Position, Element]),
    format('Результирующий список: ~w~n', [Result]).*/

insert_in(Element, 0, List, [Element|List]).
insert_in(Element, N, [Head|Tail], [Head|Result]):- N>0, N1 is N-1, insert_in(Element, N1, Tail, Result).

send_result(Result):-
    atomic_list_concat(Result, ',', Atom),
    atom_string(Atom, Result1),
    new(R, dialog('Результат')),
    send(R, append, new(text(Result1))),
    send(R, open).

:- begin_tests(insert_element).

test(insert_element_middle) :-
    insert_in(a, 2, [b,c,d], Result),
    Result == [b,c,a,d].

test(insert_element_beginning) :-
    insert_in(z, 0, [x,y], Result),
    Result == [z,x,y].

test(insert_element_end) :-
    insert_in(5, 4, [1,2,3,4], Result),
    Result == [1,2,3,4,5].

test(insert_at_position_exceed_length, [fail]) :-
    insert_in(a, 10, [b,c,d], _).

test(insert_at_empty_list) :-
    insert_in(42, 0, [], Result),
    Result == [42].

:- end_tests(insert_element).

% Запуск тестов
:- run_tests.
