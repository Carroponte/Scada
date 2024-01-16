import 'package:flutter/material.dart';
import 'package:carro_ponte_controller/view/pages/settings.dart';
import 'package:carro_ponte_controller/view/pages/console.dart';

class Navigator extends StatefulWidget {
  const Navigator({Key? key}) : super(key: key);

  @override
  State<Navigator> createState() => _NavigatorState();
}

class _NavigatorState extends State<Navigator> {
  int _currentIndex = 0;

  List<Page> pages = [
    Page("Controller", const ConsolePage()),
    Page("Impostazioni", const SettingsPage()),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: pages[_currentIndex].page,
      ),
      bottomNavigationBar: NavigationBar(
        selectedIndex: _currentIndex,
        onDestinationSelected: (int newIndex) {
          setState(() {
            _currentIndex = newIndex;
          });
        },
        destinations: const [
          NavigationDestination(
            selectedIcon: Icon(Icons.space_dashboard_rounded),
            icon: Icon(Icons.space_dashboard_outlined),
            label: "Controller",
          ),
          NavigationDestination(
            selectedIcon: Icon(Icons.settings),
            icon: Icon(Icons.settings_outlined),
            label: 'Impostazioni',
          ),
        ],
      ),
    );
  }
}

class Page {
  String name = "";
  Widget? page;

  Page(String iname, Widget ipage) {
    name = iname;
    page = ipage;
  }
}
