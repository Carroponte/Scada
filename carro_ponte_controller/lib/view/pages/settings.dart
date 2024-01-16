import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:shared_preferences/shared_preferences.dart';

class SettingsPage extends StatefulWidget {
  const SettingsPage({super.key});

  @override
  State<SettingsPage> createState() => _SettingsPageState();
}

class _SettingsPageState extends State<SettingsPage> {
  String? initialUrl = '';

  void saveUrl(String text) async {
    final prefs = await SharedPreferences.getInstance();
    prefs.setString("url", text);
  }

  void getUrl() async {
    final prefs = await SharedPreferences.getInstance();
    setState(() {
      initialUrl = prefs.getString("url") ?? '';
    });
  }

  @override
  void initState() {
    super.initState();
    getUrl();

    SystemChrome.setPreferredOrientations([
      DeviceOrientation.portraitDown,
      DeviceOrientation.portraitUp,
    ]);
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
        child: Scaffold(
      appBar: AppBar(
        centerTitle: true,
        forceMaterialTransparency: true,
        title: const Text("Impostazioni"),
      ),
      body: Padding(
        padding: const EdgeInsets.all(8.0),
        child: ListView(
          children: [
            TextField(
              controller: TextEditingController(text: initialUrl),
              decoration: const InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Indirizzo di richiesta',
              ),
              onSubmitted: (String value) {
                saveUrl(value);
              },
            ),
          ],
        ),
      ),
    ));
  }
}
