/*
 * Title:"Dungoen and dragons"
 *      
 *      core layer: Parsing XML exception
 *      
 * Description:
 *        -using to parsing xml exception, if there is exception that means there is wrong format
 * Date:2020
 * 
 * Verstion: 0.1
 * 
 * Modify Recoder;
 *  
 */
using System.Collections;
using System.Collections.Generic;
using System;

namespace Kernal
{
    public class XMLAnalysisException : Exception
    {
        public XMLAnalysisException() : base() { }

        public XMLAnalysisException(string exceptionMessage) : base(exceptionMessage) { }
    }

}
