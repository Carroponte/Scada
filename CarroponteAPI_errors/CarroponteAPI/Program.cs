-- l’elenco in ordine alfabetico dei giochi classificati per uno specifico argomento;

-- la classifica degli studenti di una certa classe virtuale, in base alle monete raccolte per un certo gioco;
select 
	nome, cognome, monete as 'monete raccolte'
from
	studenti
join 
	classi
on
	(studenti.id_classe = codice)
join 
	monetestudente
on	
	(studenti.id = id_studente)
join 
	videgiochi
on
	(monetestudente.id = id_videogioco)
where
	titolo = ''
order by monete desc;

-- il numero di classi in cui è utilizzato ciascun videogioco del catalogo;
select 
	count(id)
from
	videgiochi
join 
	videogiochiclassi
on
	(id = id_videogioco)
where
	codice_classe = '' and 
	id in (
		select distinct 
			id_videogioco 
		from 
			monetestudente
	);
