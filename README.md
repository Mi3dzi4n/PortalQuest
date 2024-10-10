# PortalQuest
Projekt 3a Gra w Unity - Miedzianowski, Szcześniewski, Kubiak, Jakubowski

### GRA KOMPUTEROWA - **Platformówka 2D z Elementami Fizycznymi**

**GŁÓWNA KONCEPCJA** -
Gracz kontroluje postać w klasycznym, dwuwymiarowym świecie, przechodząc przez różne poziomy pełne zagadek fizycznych i przeszkód. Głównym celem jest dotarcie do końca poziomu, rozwiązując łamigłówki oparte na zasadach fizyki, zbierając monety/punkty oraz unikając pułapek i przeciwników. W grze można manipulować obiektami, które reagują zgodnie z zasadami fizyki, np. przesuwać skrzynie, podnosić dźwignie, czy korzystać z platform, które działają na zasadzie równowagi.

### **ROZGRYWKA:**
1. **Sterowanie**:
   - **Poruszanie się**: Gracz steruje postacią za pomocą przycisków *asd* oraz/lub *strzałek*
   - **Skok**: *Spacja* oraz/lub *strzałka w górę*
   - **Interakcje**: Przyciski interakcji (do przesuwania obiektów, podnoszenia rzeczy, używania dźwigni lub innych mechanizmów.)

2. **Zagadki fizyczne**:
   - Zagadki oparte na mechanikach takich jak grawitacja, tarcie, popychanie i przeciąganie obiektów:
     - **Równowaga**: Gracz musi ustawić obiekty na platformach równoważnych, aby otworzyć przejście.
     - **Dźwignie i przyciski**: Przesunięcie ciężkiego obiektu na przycisk odblokowuje drzwi.
     - **Bloki fizyczne**: Przesuwanie skrzyń, aby dostać się na wyższe platformy.
   
3. **Przeciwnicy i pułapki**:
   - Proste mechaniki unikania przeciwników, którzy poruszają się po wyznaczonych trasach.
   - Pułapki, takie jak kolce, zapadnie, wirujące ostrza, które wymagają precyzyjnego skakania i refleksu.
   - Gracz może ich unikać lub wykorzystać mechaniki fizyczne, aby ich wyeliminować (np. przewrócenie ciężkiego obiektu na wroga).

4. **System zbierania punktów/monet**:
   - Na każdym poziomie porozrzucane są monety, które gracz może zbierać. Za każdą monetę gracz zdobywa punkty.
   - Dodatkowe nagrody za szybkie ukończenie poziomu.
   - **Waluta w grze**: Monety można wymieniać na skórki postaci.

5. **Poziomy trudności**:
   - Z czasem poziomy będą przechodziły na wyższy poziom trudności:
   - **Łatwy**: Mniejsze zagęszczenie pułapek, zagadki fizyczne proste, z wyraźnymi wskazówkami.
   - **Średni**: Wyzwanie stopniowo rośnie – zagadki stają się bardziej złożone, a liczba przeciwników zwiększa się.
   - **Trudny**: Zaawansowane mechaniki fizyczne, złożone interakcje między elementami gry.

### **TECHNICZNE ASPEKTY:**
   - Gra wykonana będzie w programie Unity przy pomocy języka C#.
   - Do gry będą implementowane darmowe Assety z różnych źródeł (Dźwięk, Grafika).

1. **Grafika**:
   - **Styl graficzny**: Prostota, pixel art lub grafika rysunkowa w stylu kreskówkowym.
   - **Tła**: Statyczne tła dostosowane do tematyki poziomu (np. las, jaskinia, miasto, fabryka).
   - **Animacje postaci**: Płynne animacje skoku, biegu, interakcji z obiektami.

2. **Fizyka**:
   - Silnik gry wykorzystuje wbudowany system fizyki Unity do symulowania grawitacji, tarcia, sił działających na obiekty.
   - **Obiekty interaktywne** mają swoją masę i mogą być przesuwane lub popychane przez gracza, co wpływa na ich ruch i pozycję.

3. **Wyzwania i poziomy**:
   - Każdy poziom może mieć unikalny zestaw zagadek, które wymagają logicznego myślenia i zręczności.
   - **Cele poziomów**: Zbierz określoną liczbę monet, znajdź wyjście, rozwiąż zagadki, pokonaj przeciwników lub kombinacja tych elementów.
   - **Różnorodność środowisk**: Różne motywy poziomów, jak lasy, podziemia, fabryki z wieloma ruchomymi mechanizmami, co utrzymuje rozgrywkę świeżą i angażującą.

### **ROZWÓJ GRY:**
1. **Pierwsze etapy**:
   - **Prototyp poziomu**: Stworzenie prostego poziomu z podstawowymi zagadkami fizycznymi i mechanikami skakania. (Poziom trudności: Łatwy)
   - **Dodanie systemu monet**: Wprowadzenie systemu punktacji i animacji zbierania monet.
   - **Prosta fizyka**: Implementacja skrzyń i dźwigni, które gracz może przemieszczać.
   - **Proste Menu**: Dodanie prostego Menu pozwalającego poruszać się między poziomami.

2. **Rozbudowa**:
   - **Kolejne poziomy**: Tworzenie bardziej skomplikowanych poziomów z unikalnymi zagadkami. (Poziom trudności: Średni)
   - **Dodanie przeciwników**: Implementacja wrogów, z którymi gracz musi się zmierzyć.
   - **Dodanie muzyki**: Dodanie dynamicznej muzyki do poziomów, oraz efektów dźwiękowych podczas interakcji z otoczeniem (skok, poruszanie się, przesuwanie).
   - **Menu**: Ulepszenie Menu gry, dodanie sklepu oraz funkcjonalności waluty w grze tzn. kupowania skórek postaci w sklepie.

3. **Finalizacja**:
   - **Ostatnie poziomy**: Zaimplementowanie paru bardzo wymagających poziomów do gry. (Poziom trudności: Trudny)
   - **Logo**: Stworzenie tematycznego loga gry.
   - **Testy**: Testowanie gry pod kątem fizyki, błędów w poziomach i balansu trudności.
   - **Optymalizacja**: Optymalizacja grafiki i mechanik gry pod kątem płynności działania.

**MOŻLIWOŚĆ ROZBUDOWY W PRZYSZŁOŚCI (PO ZAKOŃCZENIU PROJEKTU)**
- Dodanie multiplayera w trybie kooperacyjnym, gdzie gracze współpracują przy rozwiązywaniu zagadek.
- Integracja z usługami sieciowymi do śledzenia statystyk i wyników graczy.

**PREZENTACJA**
Zaprezentowanie gry odbędzie się poprzez stworzenie paru minutowego traileru gry, w którym pokazane będą aspekty fizyczno/logiczne gry, estetyka poziomów, wygląd menu oraz krótkie urywki z gameplayu na różnych poziomach. Całości towarzyszyć będzie podkład muzyczny.
