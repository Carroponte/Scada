import 'dart:convert';

class Status {
  late bool manuale;
  late bool emergenza;

  late bool avanti;
  late bool indietro;
  late bool destra;
  late bool sinistra;
  late bool sale;
  late bool scende;

  late bool fineCorsaX;

  late bool fineCorsaY;

  late bool inizioCorsaX;

  late bool inizioCorsaY;

  late bool movimentoX;

  late bool movimentoY;

  late bool movimento;

  late int posizione;

  Status.fromJson(String json) {
    final parsedJson = jsonDecode(json);
    final status = jsonDecode(parsedJson['data']);

    manuale = status['Manuale'];
    emergenza = status['Emergenza'];
    avanti = status['Avanti'];
    indietro = status['Indietro'];
    destra = status['Destra'];
    sinistra = status['Sinistra'];
    sale = status['Sale'];
    scende = status['Scende'];
    fineCorsaX = status['FineCorsaX'];
    fineCorsaY = status['FineCorsaY'];
    inizioCorsaX = status['InizioCorsaX'];
    inizioCorsaY = status['InizioCorsaY'];
    movimentoX = status['MovimentoX'];
    movimentoY = status['MovimentoY'];
    movimento = status['Movimento'];
    posizione = status['Posizione'];
  }
}
