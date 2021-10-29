<Cabbage>
form caption("HitSound3Del") size(400, 300), guiMode("queue") pluginId("def1")

button bounds(30, 22, 80, 40) channel("trigger")
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d
</CsOptions>
<CsInstruments>

ksmps = 32
nchnls = 2
0dbfs = 1

gaDelayL init 0
gaDelayR init 0

giDelTime init 2

instr 1
    iDel = rnd(.5)
    iDry = rnd(.6)
    aEnv expon 1, p3, 0.001
    aSigL oscili aEnv, 800+(aEnv)*800+(rnd(844))
    aSigR oscili aEnv, 124+(1-aEnv)*804+(rnd(804))
    outs aSigL*iDry, aSigR*iDry
    
    vincr gaDelayL, aSigL*iDel
    vincr gaDelayR, aSigR*iDel  
endin

instr Delay
        denorm gaDelayL, gaDelayR
ifeedback = .2+rnd(.7)
iTapR = .2+rnd(.64)

aBuf1	delayr	giDelTime
aTapL 	deltap3	.79		
aTapM 	deltap3	1		
	delayw	gaDelayL + (aTapL * ifeedback)

aBuf2	delayr	giDelTime
aTapR 	deltap3  iTapR
	delayw	gaDelayR + (aTapR * ifeedback)
                                          	
	outs	aTapL + aTapM, aTapR + aTapM   
    clear gaDelayL, gaDelayR
endin  

</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
;starts Delay and runs them for a week
i "Delay" 0 [60*60*24*7] 
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
