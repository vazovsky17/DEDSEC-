   M S B A M L   `   `   `  ????  
DEDSEC.WPF;    5DEDSEC.WPF.Components.Donations.DonationGoalComponent   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .??5      ?   ? RowDefinitions  5   
   ?? 5	      $
??auto ?6   ?? 5
      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??6    ?? Orientation$ 
Horizontal=?6"   .+?5      ??    textBlockDefault#??[  6   ??6B   ?? *Title+?? 5      $??10,0,0,0q?5      #??[  5      ??5      ?? *Description+? 5      $	??160??5      $??10,0,0,0q?5        ColorPrimary#??[ 5       ? Maximum$	 100Q?5       ? Minimum$ 0Q?5       ? Value 5      ?? *
Progress+ ?? Mode$ OneWay=??? 5      $??10,0,0,0q?5      #??[  5      ??5      ?? *	Targets+?? 5      $??Задонатить??5         optionButton#??[ 5!      ??5      ?? *AddDonationCommand+5!      5"      ?? 5$   
   $??1??5%      $
??Left=?5&      $??Center=?5'      $??18(?5(      $??SemiBold"?5)        ColorTextForeground#??[ 5*      ??5+      ?? *!DonationsViewModelsCountDisplay+y?5,      ?? *HasDonationGoal+   BooleanToVisibilityConverter ?? 	Converter# [ ?? 5.   
   $??2??5/      $??Center=?50      $??Center=?51      $??18(?52      $??SemiBold"?53      #??[ 54      $6??0Донатная цель отсутствует??55      y?56      ?? *HasDonationGoal+  BooleanNotConverter# [ &   System.Windows.Controls.DataGrid  58   
   -   5          Name$ DonationsDataGrid??59      $??2??5:        DataGridCellStyle1   	CellStyle# ?  5;        DataGridColumnHeaderStyle1	   ColumnHeaderStyle#	 ?  5<        DataGridRowStyle1
   RowStyle#
 ?  5>       	 DataGridStyle1#??? 	 5?      ??5=      ?? *DonationViewModels+y?5@      ?? *HasDonationGoal+# [    Columns 5A      4  .System.Windows.Controls.DataGridCheckBoxColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 5C         CanUserResize$ False??5D       
 CornerCheckBoxStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [
 5E         HeaderTemplate 5F      ?? 5G      .R?5H      ?? #??[
 6'   5I      5K      0  *System.Windows.Controls.DataGridTextColumn  5L      $ * 5M      $ False??5O         Header$ Донатер??5P         
IsReadOnly$
 True??5Q         Binding 5N      ?? *	Donater+5Q        5R      $ * 5S      $ False??5U      $ Количество??5V      $
 True??5W       5T      ?? *Value+5W      4  .System.Windows.Controls.DataGridTemplateColumn  5X      $
 auto 5Y      $ False??5Z      $ Действия??5[      $
 True??5\         CellTemplate 5]      ?? 5^      .R?5_      ?? $ 
Horizontal=?6)   .+?5`   "   ?? $??5,0,0,0q?5a   %     gridEditButton#??[ 5c   %   ??5b   %   ?? *EditCommand+y?5d   %   ?? *	IsAdmin+# [ .??5e   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ AccountEdit=?6<     gridButtonIcon#??[ 6O   5f   #   ?? 5g   "   $??5,0,0,0q?5h   %     gridDeleteButton#??[ 5j   %   ??5i   %   ?? *DeleteCommand+y?5k   %   ?? *	IsAdmin+# [ .??5l   &     $ Delete=?6<   #??[ 6J   5m   #   5n      5o      5q      5s      5t      5u      