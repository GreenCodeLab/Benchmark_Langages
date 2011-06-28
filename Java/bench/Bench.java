package bench;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * 	Bench
 *
 * 	Sources are under Licence LGPL
 *
 *	Made by Delfosse Jérôme for test purposee. dje@perso.be
 *	18/02/11
 */
public class Bench
{

  public static String SHA1(String text) throws NoSuchAlgorithmException, UnsupportedEncodingException
  {
    MessageDigest md;
    md = MessageDigest.getInstance("SHA-1");
    byte[] sha1hash = new byte[40];
    md.update(text.getBytes("iso-8859-1"), 0, text.length());
    sha1hash = md.digest();
    return new String(sha1hash);
  }

  /**
   * @param args the command line arguments
   */
  public static void main(String[] args)
  {
    FileWriter fstream = null;
    String strbla = "CeciestText";
    String strtoken;
    int a, b, c, d=65, e=65, f=65;
    try
    {

      long timeInMillis = System.currentTimeMillis();

      fstream = new FileWriter("java.txt");
      BufferedWriter out = new BufferedWriter(fstream);

      for (a = 65; a < 91; a++)
      {
        for (b = 65; b < 91; b++)
        {
          for (c = 65; c < 91; c++)
          {
//            for (d = 65; d < 91; d++)
//            {
//              for (e = 65; e < 91; e++)
//              {
//                for (f = 65; f < 91; f++)
//                {
                  strtoken=strbla+(char)a+(char)b+(char)c+(char)d+(char)e+(char)f;
                  out.write(strtoken+" "+SHA1(strtoken).toString()+"\n");
//                }
//              }
//            }
          }
        }
      }

      //Close the output stream
      out.close();
      System.out.println("Time ="+(System.currentTimeMillis()-timeInMillis));

    } catch (NoSuchAlgorithmException ex)
    {
      Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
    } catch (UnsupportedEncodingException ex)
    {
      Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
    } catch (IOException ex)
    {
      Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
    } finally
    {
      try
      {
        fstream.close();
      } catch (IOException ex)
      {
        Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
      }
    }
  }
}
