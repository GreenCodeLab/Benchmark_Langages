<?php
/*
 * 	Bench.c
 *
 * 	Sources are under Licence LGPL
 *
 *	Made by Delfosse Jérôme for test purposee. dje@perso.be
 *	18/02/11
 */

$bla='CeciestText';
$myfile='php.txt';

$fh=fopen($myfile,'w')
 or die("can't open file");


$d=65;
$e=65;
$f=65;

$time_start = microtime(true);

for ($a=65; $a<91; $a++)
{
	for ($b=65; $b<91; $b++)
	{
		for ($c=65; $c<91; $c++)
		{
			for ($d=65; $d<91; $d++)
			{
				for ($e=65; $e<91; $e++)
				{
//#					for ($f=65; $f<91; $f++)
//#					{
						$data=$bla.chr($a).chr($b).chr($c).chr($d).chr($e).chr($f);
						$digest = sha1($data);
						fwrite($fh,$data." ".hex2bin($digest)."\n");
						//print_r($digest);echo " ".hex2bin($digest)." \n";
//#					}
				}
			}
		}
	}
}
$time_end = microtime(true);
$time = $time_end - $time_start;

echo "Duration Time : $time seconds\n";


fclose($fh);

function hex2bin($str) {
    $bin = "";
    $i = 0;
    do {
        $bin .= chr(hexdec($str{$i}.$str{($i + 1)}));
        $i += 2;
    } while ($i < strlen($str));
    return $bin;
}

?>
