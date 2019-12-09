/**************************************************************************************************
 * Mastering Embedded System Architectures Project 3 Module 2
 * Name: g711_decoder.c
 * Author: Nick Brubaker
 * Date: 12/8/2019
 * Revision: 0
 * Description: Decodes a G.711 encoded audio file 
 *
 * Development Enviornment: Visual Studio 2008
 * External code used: 
				https://opensource.apple.com/source/tcl/tcl-20/tcl_ext/snack/snack/generic/g711.c
 *************************************************************************************************/

#include "stdafx.h"
#include <stdio.h>
 
/* From https://opensource.apple.com/source/tcl/tcl-20/tcl_ext/snack/snack/generic/g711.c */
#define	SIGN_BIT	(0x80)		/* Sign bit for a A-law byte. */
#define	QUANT_MASK	(0xf)		/* Quantization field mask. */
#define	NSEGS		(8)		/* Number of A-law segments. */
#define	SEG_SHIFT	(4)		/* Left shift for segment number. */
#define	SEG_MASK	(0x70)		/* Segment field mask. */
#define	BIAS		(0x84)		/* Bias for linear code. */
#define CLIP            8159

/* From https://opensource.apple.com/source/tcl/tcl-20/tcl_ext/snack/snack/generic/g711.c
 *
 * Snack_Mulaw2Lin() - Convert a u-law value to 16-bit linear PCM
 *
 * First, a biased linear code is derived from the code word. An unbiased
 * output can then be obtained by subtracting 33 from the biased code.
 *
 * Note that this function expects to be passed the complement of the
 * original code word. This is in keeping with ISDN conventions.
 */
short Snack_Mulaw2Lin(unsigned char	u_val)
{
	short t;

	/* Complement to obtain normal u-law value. */
	u_val = ~u_val;

	/*
	 * Extract and bias the quantization bits. Then
	 * shift up by the segment number and subtract out the bias.
	 */
	t = ((u_val & QUANT_MASK) << 3) + BIAS;
	t <<= ((unsigned)u_val & SEG_MASK) >> SEG_SHIFT;

	return ((u_val & SIGN_BIT) ? (BIAS - t) : (t - BIAS));
}

int _tmain(int argc, _TCHAR* argv[])
{
	// Open files

	FILE *inFilePtr;
	if ((inFilePtr = fopen("\\Storage Card\\encoded.wav","rb")) == NULL){
		printf("Error opening input file!");
		while(1);
		return -1;
	}

	FILE *outFilePtr;
	if ((outFilePtr = fopen("\\Storage Card\\decoded.wav","wb")) == NULL){
		printf("Error creating output file!");
		while(1);
		return -1;
	}

	// Output file header
	unsigned char header[] = {0x52, 0x49, 0x46, 0x46, 0x68, 0xaa, 0x06, 0x00, 0x57, 0x41, 0x56, 0x45, 0x66, 0x6d, 0x74, 0x20,
					0x10, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x80, 0x3e, 0x00, 0x00, 0x00, 0x7d, 0x00, 0x00, 
					0x02, 0x00, 0x10, 0x00, 0x64, 0x61, 0x74, 0x61, 0x44, 0xaa, 0x06, 0x00};

	// Skip input file header
	fseek(inFilePtr, 44, SEEK_SET);

	// Write header to output file
	fwrite((char *)header, 1, 44, outFilePtr);

	char encodedSample;
	short decodedSample;

	while (fread(&encodedSample, 1, 1, inFilePtr) != 0)
	{
		decodedSample = Snack_Mulaw2Lin(encodedSample);	// Read encoded file
		// Decode sample and write to output file
		fwrite(&decodedSample, 2, 1, outFilePtr);	
		fwrite(&decodedSample, 2, 1, outFilePtr);
	}

	// Close files
	fclose(inFilePtr);
	fclose(outFilePtr);

	return 0;
}

