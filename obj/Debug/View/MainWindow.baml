   M S B A M L   `   `   `  ����C  ?Shopicon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ShopiconShopicon  5	   	       Shopicon.View.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Shopicon     5	   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  Mainwin��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $
��auto��6   $
��auto��6*    � WindowState$ 	Maximized=�67   $
��1000��5   	   $	��500��6   .��5      �  � ColumnDefinitions 5   
    � RowDefinitions 5   
   �� 5      $��55 �6   �� 5      $��* �6   .+�5"   
   � $��1��6   .+�5#       � -   5          �Name$
 Menu��5#      5%      &   MaterialDesignThemes.Wpf.Flipper  5(   
   -   5          Name$ AccountFlipper��5)      $	��450��5*      $	��350��5+      $��2��5,      $y�	Collapsed=�5-      	   FrontContent	 5/      � 50      $��2��6   $	��350��6%   $	��450��61   .+�51       � -   5        $ Login��51      52      
   BackContent
 54      � 55      $��2��6   $	��350��6%   $	��450��61   .+�56       � -   5        $ Registration��56      57      59       � 5<   
   -   5        $ AccountMenu��5<      $��1��5>      $	��300��5?      $	��250��5@      $	��Top=�5A      $��Right=�5B      $	��7.5q�5C      $��2q�5D      $y�	Collapsed=�5E        MaterialDesignDivider#���  5F      5G      5H      