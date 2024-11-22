using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsageCollections
{
	public class Etudiant
	{
		// Propriétés
		public string Nom { get; set; }
		public double NoteCC { get; set; } // Note de contrôle continu
		public double NoteDevoir { get; set; } // Note de devoir

		// Propriété calculée pour la moyenne pondérée
		public double Moyenne
		{
			get
			{
				return (NoteCC * 0.33) + (NoteDevoir * 0.67);
			}
		}
	}
}