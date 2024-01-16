import 'package:flutter/material.dart';
import 'view/navigator.dart' as app;

void main() {
  runApp(MaterialApp(
    title: 'Carroponte Controller',
    theme: ThemeData(
      scaffoldBackgroundColor: const Color.fromARGB(255, 248, 248, 248),
      colorScheme: ColorScheme.fromSeed(
          seedColor: const Color.fromARGB(255, 0, 132, 255)),
      useMaterial3: true,
    ),
    home: const app.Navigator(),
  ));
}
