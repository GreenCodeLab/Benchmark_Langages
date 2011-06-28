#include <stdio.h>
#include <stdlib.h>
#include <sys/time.h>
#include "sha1.h"

/* **********************************************************************************************************
 * 	Bench.c
 *
 * 	Sources are under Licence LGPL
 *
 *	Made by Delfosse Jérôme for test purposee. dje@perso.be
 *	18/02/11
 * **********************************************************************************************************
*/

int main()
{
	SHA1Context sha;
	char bla[]="CeciestText";
	char a,b,c,d,e,f;
	char token[18];
	char shatoken[20];
	char *ptr;
	FILE *file;
	int i,j;
	struct timeval start, end;

	long mtime, seconds, useconds;



	file = fopen("C.txt","wb");

	d=65;
	e=65;
	f=65;




	gettimeofday(&start, NULL);

	for (a=65; a<91; a++)
		for (b=65; b<91; b++)
			for (c=65; c<91; c++)
//          for (d=65; d<91; d++)
//            for (e=65; e<91; e++)
//              for (f=65; f<91; f++)
			{
				SHA1Reset(&sha);

				strcpy(token,bla);
				token[11]=a;
				token[12]=b;
				token[13]=c;
				token[14]=d;
				token[15]=e;
				token[16]=f;
				token[17]='\0';

				ptr=token;
				ptr+=11;

				SHA1Input(&sha, (const unsigned char *) token, 17);

				if (!SHA1Result(&sha))
				{
					fprintf(stderr, "ERROR-- could not compute message digest\n");
				}
				else
				{
					for (i=0; i<5; i++) //revert little indian
						for (j=0; j<4; j++)
						{
							shatoken[i*4+j]=(sha.Message_Digest[i]&(0xFF000000>>(j*8)))>>((3-j)*8);
						}//endfor
				}//endif SHA1Result
				fprintf(file,"%s ",token);
				fwrite(shatoken,20,1,file);
				fprintf(file,"\n");

			}//endfor f
	fclose(file);


	gettimeofday(&end, NULL);

	seconds  = end.tv_sec  - start.tv_sec;
	useconds = end.tv_usec - start.tv_usec;
	mtime = ((seconds) * 1000 + useconds/1000.0) + 0.5;
	printf("Elapsed time: %ld milliseconds\n", mtime);


}
