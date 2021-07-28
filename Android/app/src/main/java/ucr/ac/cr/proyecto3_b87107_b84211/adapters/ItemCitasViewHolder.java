package ucr.ac.cr.proyecto3_b87107_b84211.adapters;

import android.view.View;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import org.jetbrains.annotations.NotNull;

import ucr.ac.cr.proyecto3_b87107_b84211.R;

public class ItemCitasViewHolder extends RecyclerView.ViewHolder{
    TextView fecha;
    TextView centro_salud;
    ConstraintLayout layoutDetalles;
    TextView especialidad;
    TextView descripcion;
    TextView medico;
    TextView verDetalles;


    public ItemCitasViewHolder(@NonNull @NotNull View itemView) {
        super(itemView);
        fecha= itemView.findViewById(R.id.txtFecha);
        centro_salud= itemView.findViewById(R.id.txtCentro_Salud);
        layoutDetalles=itemView.findViewById(R.id.itemMasDetalles);
        especialidad=itemView.findViewById(R.id.txtEspecialidadValor);
        descripcion=itemView.findViewById(R.id.txtDescValor);
        medico=itemView.findViewById(R.id.txtMedicoValor);
        verDetalles=itemView.findViewById(R.id.txtDetalles);
    }
}
