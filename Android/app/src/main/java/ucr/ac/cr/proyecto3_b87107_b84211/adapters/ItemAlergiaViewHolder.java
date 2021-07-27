package ucr.ac.cr.proyecto3_b87107_b84211.adapters;

import android.view.View;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import org.jetbrains.annotations.NotNull;

import ucr.ac.cr.proyecto3_b87107_b84211.R;

public class ItemAlergiaViewHolder extends RecyclerView.ViewHolder {
    TextView vacuna;
    TextView fecha;
    ConstraintLayout layoutDetalles;
    TextView medicamentos;
    TextView descripcion;
    TextView verDetalles;

    public ItemAlergiaViewHolder(@NonNull @NotNull View itemView) {
        super(itemView);
        vacuna= itemView.findViewById(R.id.txtAlergia);
        fecha= itemView.findViewById(R.id.txtFecha);
        layoutDetalles=itemView.findViewById(R.id.itemMasDetalles);
        medicamentos=itemView.findViewById(R.id.txtMedicamentosAlergiaValor);
        descripcion=itemView.findViewById(R.id.txtDescAlergiaValor);
        verDetalles=itemView.findViewById(R.id.txtDetalles);

    }
}
