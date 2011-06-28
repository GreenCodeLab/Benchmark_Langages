#!/usr/bin/perl
use Time::HiRes qw(gettimeofday tv_interval);
use Digest::SHA1  qw(sha1 sha1_hex sha1_base64);

#	Bench.c
#	Sources are under Licence LGPL
#
#	Made by Delfosse Jérôme for test purposee. dje@perso.be
#	18/02/11


my $bla='CeciestText';
my $data,$digest;
my $elapsed;
my $a,$b,$c,$d,$e,$f;

open (MYFILE, '>perl.txt');
$t0 = [gettimeofday];
$d=65;
$e=65;
$f=65;

for ($a=65; $a<91; $a++)
{
	for ($b=65; $b<91; $b++)
	{
		for ($c=65; $c<91; $c++)
		{
#			for ($d=65; $d<91; $d++)
#			{
#				for ($e=65; $e<91; $e++)
#				{
#					for ($f=65; $f<91; $f++)
#					{
						$data=$bla.chr($a).chr($b).chr($c).chr($d).chr($e).chr($f);
						$digest = sha1($data);
						print MYFILE "$data $digest\n";
#					}
#				}
#			}
		}
	}
}

$elapsed = tv_interval($t0);
$elapsed*=1000;

close (MYFILE); 

print "Time ms: $elapsed \n";

