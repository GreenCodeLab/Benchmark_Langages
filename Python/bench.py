#!python
# cracktoken.py 

import hashlib
import time

"""
 * 	Bench.c
 *
 * 	Sources are under Licence LGPL
 *
 *	Made by Delfosse Jérôme for test purposee. dje@perso.be
 *	18/02/11
"""

#http://skymind.com/~ocrow/python_string/

filename = "python.txt"
file = open(filename, 'w')
t0=time.time()
bla="CeciestTest"

d=65
e=65
f=65

for a in range(65,91):
	for b in range(65,91):
		for c in range(65,91):
#			for d in range(65,90):
#				for e in range(65,90):
#					for f in range(65,90):
						strtoken=bla+chr(a)+chr(b)+chr(c)+chr(d)+chr(e)+chr(f)
						m = hashlib.sha1()
						m.update(strtoken)
						file.write(strtoken+" "+m.digest()+"\n")
file.close()
print("time ms : ",(time.time()-t0)*1000)
