import 'package:carro_ponte_controller/controller/general_utility_controller.dart';
import 'package:carro_ponte_controller/models/status_model.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class ApiController {
  String BASE_URL = '';

  static const DESTRA_ENDPOINT = 'destra';
  static const SINISTRA_ENDPOINT = 'sinistra';
  static const AVANTI_ENDPOINT = 'avanti';
  static const INDIETRO_ENDPOINT = 'indietro';
  static const SALE_ENDPOINT = 'sale';
  static const SCENDE_ENDPOINT = 'scende';

  static const STATUS_ENDPOINT = 'status';

  ApiController(String baseUrl) {
    BASE_URL = baseUrl;
  }

  Future<Status?> getStatus() async {
    try {
      final url = Uri.parse('$BASE_URL/$STATUS_ENDPOINT');

      final response = await http.get(url);

      if (response.statusCode == 200) {
        return Status.fromJson(response.body);
      } else {
        return null;
      }
    } catch (e) {
      print(e.toString());
      return null;
    }
  }

  Future<Response> sendPost(String endPoint) {
    try {
      final url = Uri.parse('$BASE_URL/$endPoint/');

      return http.post(url);
    } catch (_) {
      return Future.error(
          "Errore durante la richiesta Post all'endpoint $endPoint");
    }
  }

  Future<Response> sendGet(String endPoint) {
    try {
      final url = Uri.parse('$BASE_URL/$endPoint/');

      return http.get(url);
    } catch (_) {
      return Future.error(
          "Errore durante la richiesta Post all'endpoint $endPoint");
    }
  }
}
