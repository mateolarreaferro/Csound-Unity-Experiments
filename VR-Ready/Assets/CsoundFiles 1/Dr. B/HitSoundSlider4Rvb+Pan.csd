<Cabbage>
form caption("HitSoundSlider4RvbPan") size(400, 300), guiMode("queue") pluginId("def1")

button bounds(30, 22, 80, 40) channel("trigger")
hslider bounds(32, 76, 150, 49) channel("freq") range(40, 4000, 400, 1, 0.001) , 
hslider bounds(32, 142, 150, 50) channel("pan") range(0, 1, .5, 1, 0.001)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d
</CsOptions>
<CsInstruments>
; Initialize the global variables. 
ksmps = 32
nchnls = 2
0dbfs = 1

gaRevL init 0
gaRevR init 0


instr 1

    iDryLevel = rnd(.7)
    iRvbSend = rnd(.24)
    
    aEnv expon 1, p3, 0.001
    
    aSigL oscili aEnv, chnget:i("freq")*aEnv+(rnd(1500))
    aSigR oscili aEnv, chnget:i("freq")*(1-aEnv)+(rnd(6000))
    aMix = (aSigL+aSigR)*iDryLevel
    
    aPanL, aPanR pan2 aMix, chnget:i("pan")
    outs aPanL, aPanR
    
    vincr gaRevL, aPanL*iRvbSend
    vincr gaRevR, aPanR*iRvbSend  
endin

instr Reverb
        denorm gaRevL, gaRevR
aL, aR  freeverb gaRevL, gaRevR, 0.79, 0.25, sr, 0
        outs aL, aR    
        clear gaRevL, gaRevR
endin  

</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
;starts Reverb and runs it for a week
i "Reverb" 0 [60*60*24*7] 
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>100</x>
 <y>100</y>
 <width>320</width>
 <height>240</height>
 <visible>true</visible>
 <uuid/>
 <bgcolor mode="nobackground">
  <r>255</r>
  <g>255</g>
  <b>255</b>
 </bgcolor>
</bsbPanel>
<bsbPresets>
</bsbPresets>