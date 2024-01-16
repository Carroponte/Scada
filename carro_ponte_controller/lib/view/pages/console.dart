import 'package:carro_ponte_controller/controller/api_controller.dart';
import 'package:carro_ponte_controller/controller/general_utility_controller.dart';
import 'package:carro_ponte_controller/models/status_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'dart:async';

class ConsolePage extends StatefulWidget {
  const ConsolePage({super.key});

  @override
  State<ConsolePage> createState() => _ConsolePageState();
}

class _ConsolePageState extends State<ConsolePage> {
  ApiController? _apiController;
  Status? _pclStatus;
  Timer? timer;

  void getUrl() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    setState(() {
      _apiController =
          ApiController(prefs.getString('url') ?? 'localhost:5081');
    });
  }

  @override
  void initState() {
    super.initState();

    SystemChrome.setPreferredOrientations([
      DeviceOrientation.landscapeLeft,
      DeviceOrientation.landscapeRight,
    ]);
  }

  Future<void> getStatus() async {
    var response = await _apiController?.getStatus();
    try {
      if (response != null) {
        setState(() {
          _pclStatus = response;
        });
      } else {
        GeneralUtilityController.showError(
            context, "Errore durante la richiesta dello status", "Errore");
      }
    } catch (_) {}
  }

  Future<void> sendRequest(String endPoint) async {
    var response = await _apiController?.sendPost(endPoint);

    if (response == null || response.statusCode != 200) {
      GeneralUtilityController.showError(context,
          response?.statusCode.toString() ?? 'Errore generico', "Errore");
    }

    getStatus();
  }

  @override
  Widget build(BuildContext context) {
    if (_apiController == null) {
      getUrl();
      return const Center(
          child: CircularProgressIndicator(
        color: Colors.amber,
      ));
    }

    if (timer == null && _apiController != null) {
      setState(() {
        timer = Timer.periodic(Duration(seconds: 1), (timer) {
          getStatus();
        });
      });
    }

    if (_pclStatus == null) {
      //getStatus();
      return const Center(
          child: CircularProgressIndicator(
        color: Colors.blue,
      ));
    } else if (_pclStatus?.manuale == false) {
      return const Center(
          child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          CircularProgressIndicator(
            color: Colors.blue,
          ),
          SizedBox(
            height: 20,
          ),
          Text('Il controller può essere utilizzato solo in modalità '
              'manuale, modificare l\'impostazione e riprovare tra'
              ' qualche secondo')
        ],
      ));
    }

    return SafeArea(
        child: Row(
      children: [
        Expanded(
            child: Column(
          children: [
            Expanded(
                child: GestureDetector(
              onTap: () {
                sendRequest(ApiController.SALE_ENDPOINT);
              },
              child: Container(
                decoration: BoxDecoration(
                    border: Border.all(color: Colors.black, width: 1),
                    color: _pclStatus!.sale ? Colors.green : Colors.blueGrey),
                width: 500,
                child: const Icon(Icons.arrow_upward),
              ),
            )),
            Expanded(
                child: GestureDetector(
              onTap: () {
                sendRequest(ApiController.SCENDE_ENDPOINT);
              },
              child: Container(
                width: 500,
                decoration: BoxDecoration(
                    border: Border.all(color: Colors.black, width: 1),
                    color: _pclStatus!.scende ? Colors.green : Colors.blueGrey),
                child: const Icon(Icons.arrow_downward),
              ),
            )),
          ],
        )),
        Expanded(
            child: Column(
          children: [
            Expanded(
                child: Row(
              children: [
                Expanded(
                    child: Container(
                  child: Text(
                    "E",
                    textAlign: TextAlign.center,
                  ),
                  alignment: Alignment.center,
                  height: 500,
                  decoration: BoxDecoration(
                    image: _pclStatus?.posizione != 5
                        ? DecorationImage(
                            image: AssetImage('assets/wood.png'),
                            fit: BoxFit.fill)
                        : null,
                    border: Border.all(color: Colors.black, width: 1),
                    color:
                        _pclStatus?.posizione == 5 ? Colors.green : Colors.grey,
                  ),
                )),
                Expanded(
                    child: Container(
                  height: 500,
                  alignment: Alignment.center,
                  child: Text(
                    "F",
                    textAlign: TextAlign.center,
                  ),
                  decoration: BoxDecoration(
                    image: _pclStatus?.posizione != 6
                        ? DecorationImage(
                            image: AssetImage('assets/wood.png'),
                            fit: BoxFit.fill)
                        : null,
                    border: Border.all(color: Colors.black, width: 1),
                    color:
                        _pclStatus?.posizione == 6 ? Colors.green : Colors.grey,
                  ),
                ))
              ],
            )),
            Expanded(
                child: Row(children: [
              Expanded(
                  child: Container(
                alignment: Alignment.center,
                height: 500,
                child: Text(
                  "C",
                  textAlign: TextAlign.center,
                ),
                decoration: BoxDecoration(
                  image: _pclStatus?.posizione != 3
                      ? DecorationImage(
                          image: AssetImage('assets/wood.png'),
                          fit: BoxFit.fill)
                      : null,
                  border: Border.all(color: Colors.black, width: 1),
                  color:
                      _pclStatus?.posizione == 3 ? Colors.green : Colors.grey,
                ),
              )),
              Expanded(
                  child: Container(
                alignment: Alignment.center,
                height: 500,
                child: Text(
                  "D",
                  textAlign: TextAlign.center,
                ),
                decoration: BoxDecoration(
                  image: _pclStatus?.posizione != 4
                      ? DecorationImage(
                          image: AssetImage('assets/wood.png'),
                          fit: BoxFit.fill)
                      : null,
                  border: Border.all(color: Colors.black, width: 1),
                  color:
                      _pclStatus?.posizione == 4 ? Colors.green : Colors.grey,
                ),
              ))
            ])),
            Expanded(
                child: Row(children: [
              Expanded(
                  child: Container(
                alignment: Alignment.center,
                height: 500,
                child: Text(
                  "A",
                  textAlign: TextAlign.center,
                ),
                decoration: BoxDecoration(
                  image: _pclStatus?.posizione != 1
                      ? DecorationImage(
                          image: AssetImage('assets/wood.png'),
                          fit: BoxFit.fill)
                      : null,
                  border: Border.all(color: Colors.black, width: 1),
                  color:
                      _pclStatus?.posizione == 1 ? Colors.green : Colors.grey,
                ),
              )),
              Expanded(
                  child: Container(
                alignment: Alignment.center,
                height: 500,
                child: Text(
                  "B",
                  textAlign: TextAlign.center,
                ),
                decoration: BoxDecoration(
                  image: _pclStatus?.posizione != 2
                      ? DecorationImage(
                          image: AssetImage('assets/wood.png'),
                          fit: BoxFit.fill)
                      : null,
                  border: Border.all(color: Colors.black, width: 1),
                  color:
                      _pclStatus?.posizione == 2 ? Colors.green : Colors.grey,
                ),
              ))
            ]))
          ],
        )),
        Expanded(
            child: Column(
          children: [
            Expanded(
                child: GestureDetector(
              onTap: () {
                sendRequest(ApiController.AVANTI_ENDPOINT);
              },
              child: Container(
                width: 500,
                decoration: BoxDecoration(
                    border: Border.all(color: Colors.black, width: 1),
                    color: _pclStatus!.avanti ? Colors.green : Colors.blueGrey),
                child: const Icon(Icons.arrow_upward),
              ),
            )),
            Expanded(
                child: Row(
              children: [
                Expanded(
                    child: GestureDetector(
                  onTap: () {
                    sendRequest(ApiController.SINISTRA_ENDPOINT);
                  },
                  child: Container(
                    width: 500,
                    height: 500,
                    decoration: BoxDecoration(
                        border: Border.all(color: Colors.black, width: 1),
                        color: _pclStatus!.sinistra
                            ? Colors.green
                            : Colors.blueGrey),
                    child: const Icon(Icons.arrow_left),
                  ),
                )),
                Expanded(
                    child: GestureDetector(
                  onTap: () {
                    sendRequest(ApiController.DESTRA_ENDPOINT);
                  },
                  child: Container(
                    width: 500,
                    height: 500,
                    decoration: BoxDecoration(
                        border: Border.all(color: Colors.black, width: 1),
                        color: _pclStatus!.destra
                            ? Colors.green
                            : Colors.blueGrey),
                    child: const Icon(Icons.arrow_right),
                  ),
                )),
              ],
            )),
            Expanded(
                child: GestureDetector(
              onTap: () {
                sendRequest(ApiController.INDIETRO_ENDPOINT);
              },
              child: Container(
                width: 500,
                decoration: BoxDecoration(
                    border: Border.all(color: Colors.black, width: 1),
                    color:
                        _pclStatus!.indietro ? Colors.green : Colors.blueGrey),
                child: const Icon(Icons.arrow_downward),
              ),
            )),
          ],
        )),
      ],
    ));
  }
}
