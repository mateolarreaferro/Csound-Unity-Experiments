<Cabbage>
form caption("Untitled") size(400, 300), guiMode("queue") pluginId("def1")
rslider bounds(296, 162, 100, 100), channel("gain"), range(0, 1, 0.5, 1, 0.01), text("Gain"), trackerColour(0, 255, 0, 255), outlineColour(0, 0, 0, 50), textColour(0, 0, 0, 255)
combobox bounds(114, 28, 80, 20) text("Sine", "Triangle", "Sawtooth", "Square", "Pulse") fontColour(188, 151, 49, 255) channel("WaveformSelection")
button bounds(24, 50, 80, 40) channel("Trigger") text("Trigger")

</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -+rtmidi=NULL -M0 -m0d 
</CsOptions>
<CsInstruments>
; Initialize the global variables. 
ksmps = 32
nchnls = 2
0dbfs = 1

//Waveforms
giSine ftgen 1, 0, 8192, 10, 1
giTriangle ftgen 2,0, 8192, 9, 1, 1, 0, 3, .333, 180, 5, .2, 0, 7, .143, 180, 9, .111, 0
giSaw ftgen 3, 0, 8192, 10, 1, .5, .333, .25, .2, .166, .143, .125, .111, .1, .0909, .0833, .077
giSquare ftgen 4, 0, 8192, 10, 1, 0, .333, 0, .2, 0, .143, 0, .111, 0, .0909, 0, .077, 0, .0666, 0, .0588
giPulse ftgen 5, 0, 8192, 10, 1, 1, 1, 1, 0.7, 0.5, 0.3, 0.1

instr Trigger
    kTrigger chnget "Trigger"
    
    if changed(kTrigger) == 1 then
        event "i", 1, 0, 1
    endif
    
endin

instr 1
    kGain   chnget  "gain"
    iFn     chnget  "WaveformSelection"
    aEnv    linseg  0,  0.1,    1   , 0.1,  0

    a1  poscil 1 * aEnv, 300, iFn

    outs a1 * kGain, a1 * kGain
endin

</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
;starts instrument 1 and runs it for a week
i "Trigger" 0 [60*60*24*7] 
</CsScore>
</CsoundSynthesizer>
