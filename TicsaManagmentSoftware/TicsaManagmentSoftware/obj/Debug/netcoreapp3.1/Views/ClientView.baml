   M S B A M L   `   `   `  ����Q  MTicsaManagmentSoftware, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:TicsaManagmentSoftware.ViewsTicsaManagmentSoftware.Views  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      S.clr-namespace:TicsaManagmentSoftware.ViewModel TicsaManagmentSoftware.ViewModel  5      -    'TicsaManagmentSoftware.Views.ClientView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:TicsaManagmentSoftware.Views     5      6sys&clr-namespace:System;assembly=mscorlib     5      D	viewmodel.clr-namespace:TicsaManagmentSoftware.ViewModel     5        � 	Resources  5         dataFromEnum S� 
MethodName S� 
ObjectTypeU QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum S� MethodParameters M� TypeName6   0TicsaManagmentSoftware.ViewModel.ClientViewModel 	 model��%�   &	        &	 t     S� 5   
   $ 	GetValues��62   "  5       5      M� 5      $ local:QueryTypeEnum��6   5        5   
   64   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��680 �6   �� 5      $	��380 �6   .+�5   
   �� $��0��6   .+�5      �� -   5         ��Name$ ___ProjectSaveListView_��5      $��
10,10,10,0q�68    �� SelectionMode$ Single=�6L   $	��600��6c   ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value$	
 Top=�6E   5       �� View 5!      �� 5"      -   5        ___ClientsGridView_��.P�5#      �� -   5        $ ___ClientLastNameGridViewColumn_��$��Nom de famille��5#   S    �� Width$
 Auto��6�    �� DisplayMemberBinding 6k   �� *
LastName+6�   �� 5$      -   5        %!___ClientFirstNameGridViewColumn_��$��Prénom��5$   T   $
 Auto��6�    6d   �� *	FirstName+6�   �� 5%      -   5        '#___CompagnieNameNameGridViewColumn_��$��Nom de la Compagnie��5%   V   $
 Auto��6�    6s   �� *CompagnieName+6�   �� 5&      -   5        ___EmailGridViewColumn_��$��Email��5&   J   $
 Auto��6�    6Y   �� *Email+6�   �� 5'      -   5        %!___PhoneNumberNameGridViewColumn_��$��Numéro de Téléphone��5'   T   $
 Auto��6�    6q   �� *PhoneNumber+6�   �� 5(      -   5        !___AddressNameGridViewColumn_��$��Adresse��5(   P   $
 Auto��6�    6a   �� *	Address+6�   �� 5)      -	   5        $ ___PostalCodeNameGridViewColumn_��$��Code postal��5)   S   $
 Auto��6�    6h   �� *
PostalCode+6�   5*      5,      � 5-       5.      �� 5/      $��* �6'   �� 50      $��* �6'   .+�52      �� -
   5         ��Name$ ___RefreshClientsButton_��52      $��
Actualiser��6;   $��0��6w   $��10q�6�   �� 53      -   5        $ ___DeleteClientsButton_��53      $��	Supprimer��6:   $��1��6t   $��10q�6�   54      55      �� 56   
   $��1��6   .+�57      �� -   5         ��Name$ ___SQLConnectorComboBox_��57      $��10q�69   $��10q�6E   $
��Auto��6R   ��6_   ��  �� Source# [  58      59      5;      