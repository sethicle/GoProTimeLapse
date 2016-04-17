Imports Microsoft.SPOT
Imports Microsoft.SPOT.Hardware
Imports SecretLabs.NETMF.Hardware
Imports SecretLabs.NETMF.Hardware.Netduino
Imports Toolbox.NETMF.Hardware


Module GoPro_TimeLapse



    Sub Main()
        Dim RTC As DS1307 = New DS1307()
        Dim TimeHour As String
        Dim TimeSecond As Double = DateTime.Now.Second
        Dim led = New OutputPort(Pins.ONBOARD_LED, False)
        Dim CamRelay = New OutputPort(Pins.GPIO_PIN_D5, False)
        Dim TimeDay As String

        RTC.SetTime(Year:=2016, Month:=4, Day:=13, Hour:=23, Minute:=6, Second:=30) 'time set to current time. set once at initial install then commented.
        RTC.Synchronize()
        TimeHour = DateTime.Now.ToString("HH")
        TimeDay = DateTime.Now.ToString("dddd")
        Debug.Print(TimeHour)
        Debug.Print(TimeDay)
        Debug.Print(DateTime.Now.ToString())
        Do
            Select Case TimeHour
                Case 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 23, 24

                    TimeSecond = DateTime.Now.Second
                    If TimeSecond = 1 OrElse TimeSecond = 3 OrElse TimeSecond = 5 OrElse TimeSecond = 7 OrElse TimeSecond = 9 _
                        OrElse TimeSecond = 11 OrElse TimeSecond = 13 OrElse TimeSecond = 15 OrElse TimeSecond = 17 OrElse TimeSecond = 19 OrElse TimeSecond = 21 Then
                        led.Write(True)
                        CamRelay.Write(True)
                    Else
                        led.Write(False)
                        CamRelay.Write(False)

                    End If
                    Debug.Print(TimeHour)
                    TimeHour = DateTime.Now.ToString("HH")
                    Debug.Print(DateTime.Now.ToString())
                    Thread.Sleep(1000)

            End Select
        Loop

        ' If DateTime.Now.Hour = 23 Then
        'Debug.Print(DateTime.Now.ToString())
        'End If

    End Sub

End Module
