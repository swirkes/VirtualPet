   M S B A M L   `   `   `  ����R  NTamagotchiUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TamagotchiUserInterfaceTamagotchiUserInterface  5   	   (    "TamagotchiUserInterface.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:TamagotchiUserInterface     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5
         T1Hungry  T2Hungry  T3Hungry  T1Sleep  T2Sleep  T3Sleep 
 T1Dead 
 T2Dead 
 T3Dead 	 T1Normal 
 T2Normal  T3Normal��%i  &	        &	 �     &	     &	 �    &	     &	 �    &	     &	 �    &	     &		 �    &	
 �    &	 v    �� 5   
   $O��IC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi1Hungry.png��6!   $	��125��6t   $	��108��6�   �� 5   
   $O��IC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi2Hungry.png��6!   $	��125��6t   $	��108��6�   �� 5   
   $O��IC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi3Hungry.png��6!   $	��125��6t   $	��108��6�   �� 5   
   $N��HC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi1Sleep.png��6    $	��125��6r   $	��108��6   �� 5   
   $N��HC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi2Sleep.png��6    $	��125��6r   $	��108��6   �� 5   
   $N��HC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi3Sleep.png��6    $	��125��6r   $	��108��6   �� 5   
   $M��GC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi1Dead.png��6   $	��125��6p   $	��108��6}   �� 5   
   $M��GC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi2Dead.png��6   $	��125��6p   $	��108��6}   �� 5   
   $M��GC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi3Dead.png��6   $	��125��6p   $	��108��6}   �� 5   
   $I��CC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi1.png��6!   $	��125��6n   $	��108��6{   �� 5   
   $I��CC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi2.png��6!   $	��125��6n   $	��108��6{   �� 5   
   $I��CC:\Users\swirk\source\repos\TamagotchiUserInterface\Tamagotchi3.png��6!   $	��125��6n   $	��108��6{   5      .��5      �  J� RenderTransformOrigin$ 0.494,0.509&�6    � ColumnDefinitions 5   
   �� 5      $
��158* �6   �� 5      $	��50* �6   �� 5      $
��587* �6   .+�5   
   �� $
��Left=�6   $��	63,10,0,0q�6/   $
��Wrap=�6B   $1��+Choose a Tamagotchi to play dodgeball with:��6V   $	��Top=�6�   $ -0.442,-0.289&�6�   $��41��6�   $	��241��6�   $��2��6�   �� 5   
   -   5         ��Name$ Tamagotchi1btn��5      $��Button��6)   $��156,172,0,0q�6:   $	��108��6O   $	��125��6[   $	��Top=�6h   $
��Left=�6�   $��3��6�   6�   �� 5    
   -   5        $ Tamagotchi2btn��5       $��Button��6)   $��135,172,0,0q�6:   $	��108��6O   $	��125��6[   $	��Top=�6h   $
��Left=�6�   $ 0.201,0.539&�6�   $��2��6�   6�   �� 5!   
   -   5        $ Tamagotchi3btn��5!      $��Button��6)   $��334,172,0,0q�6:   $	��108��6O   $	��125��6[   $	��Top=�6h   $
��Left=�6�   $��2��6�   6�   �� 5"   
   -   5         ��Name$ lblHappiness1��5"      $�� ��6'   $
��Left=�62   $��156,326,0,0q�6M   $	��Top=�6b   $ -0.408,0.115&�6z   $��3��6�   $	��168��6�   �� 5#   
   -   5        $ lblHappiness2��5#      $�� ��6'   $��2��62   $
��Left=�6B   $��135,326,0,0q�6]   $	��Top=�6r   $	��169��6�   �� 5$   
   -   5        $ lblHappiness3��5$      $�� ��6'   $��2��62   $
��Left=�6B   $��334,326,0,0q�6]   $	��Top=�6r   $ 0.461,-0.481&�6�   $	��177��6�   �� 5%   
   -   5        $ Feed1��5%      $��2��6    $
��Feed��64   $��1��6C   $
��Left=�6S   $��	0,102,0,0q�6n   $	��Top=�6�   $��75��6�   6�   �� 5&   
   -	   5        $ Feed2��5&      $
��Feed��6    $��2��6/   $
��Left=�6?   $��135,102,0,0q�6Z   $	��Top=�6o   $��75��6�   6�   �� 5'   
   -
   5        $ Feed3��5'      $
��Feed��6    $��2��6/   $
��Left=�6?   $��334,102,0,0q�6Z   $	��Top=�6o   $��76��6�   6�   �� 5(   
   -   5        $ Sleep1��5(      $��2��6!   $��Give Pillow��65   $��1��6K   $
��Left=�6[   $��	0,127,0,0q�6v   $	��Top=�6�   $��75��6�   6�   �� 5)   
   -   5        $ Sleep2��5)      $��Give Pillow��6!   $��2��67   $
��Left=�6G   $��135,127,0,0q�6b   $	��Top=�6w   $��75��6�   6�   �� 5*   
   -   5        $ Sleep3��5*      $��Give Pillow��6!   $��2��67   $
��Left=�6G   $��334,127,0,0q�6b   $	��Top=�6w   $��75��6�   6�   5,      5-      