import javax.swing.*;
import java.awt.*;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class ProductApp extends JFrame {
    private List<Product> products;
    private JPanel mainPanel;

    public ProductApp() {
        setTitle("Product Viewer");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());

        products = new ArrayList<>();

        // Меню
        JMenuBar menuBar = new JMenuBar();
        JMenu menu = new JMenu("File");
        JMenuItem loadItem = new JMenuItem("Load from File");
        JMenuItem autoFillItem = new JMenuItem("Auto Fill");
        menu.add(loadItem);
        menu.add(autoFillItem);
        menuBar.add(menu);
        setJMenuBar(menuBar);

        // Главная панель с прокруткой
        mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        JScrollPane scrollPane = new JScrollPane(mainPanel);
        add(scrollPane, BorderLayout.CENTER);

        // Радиокнопки для смены Look and Feel
        addLookAndFeelSwitcher();

        // Обработчики событий меню
        loadItem.addActionListener(e -> loadProductsFromFile());
        autoFillItem.addActionListener(e -> autoFillProducts());

        setVisible(true);
    }

    private void loadProductsFromFile() {
        try (FileReader fr = new FileReader("formatted_products.txt")) {
            products.clear();
            Scanner scanner = new Scanner(fr);
            while (scanner.hasNextLine()) {
                Product product = ProductIO.readFormatProduct(scanner);
                if (product != null) {
                    products.add(product);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        };
        displayProducts();
    }

    private void autoFillProducts() {
        products.clear();
        for (int i = 0; i < 10; i++) {
            products.add(new ProductInStore("Product " + i, i * 10, List.of(4, 5, 3), i * 20));
        }
        displayProducts();
    }

    private void displayProducts() {
        mainPanel.removeAll();
        for (int i = 0; i < products.size(); i++) {
            Product product = products.get(i);
            JPanel productPanel = new JPanel();
            productPanel.setLayout(new BorderLayout());
            productPanel.setBorder(BorderFactory.createTitledBorder("Product " + (i + 1)));
            productPanel.add(new JLabel(product.toString()), BorderLayout.CENTER);

            int finalI = i;
            productPanel.addMouseListener(new java.awt.event.MouseAdapter() {
                @Override
                public void mouseClicked(java.awt.event.MouseEvent e) {
                    JOptionPane.showMessageDialog(
                            ProductApp.this,
                            "Product #" + (finalI + 1) + ": " + product,
                            "Product Details",
                            JOptionPane.INFORMATION_MESSAGE
                    );
                }
            });

            mainPanel.add(productPanel);
        }
        mainPanel.revalidate();
        mainPanel.repaint();
    }

    private void addLookAndFeelSwitcher() {
        JPanel lookAndFeelPanel = new JPanel();
        ButtonGroup group = new ButtonGroup();
        String[] plafs = {"Metal", "Nimbus", "Motif", "Windows"};
        for (String plaf : plafs) {
            JRadioButton radioButton = new JRadioButton(plaf);
            radioButton.addActionListener(e -> changeLookAndFeel(plaf));
            group.add(radioButton);
            lookAndFeelPanel.add(radioButton);
        }
        add(lookAndFeelPanel, BorderLayout.NORTH);
    }

    private void changeLookAndFeel(String plaf) {
        try {
            switch (plaf) {
                case "Metal" -> UIManager.setLookAndFeel("javax.swing.plaf.metal.MetalLookAndFeel");
                case "Nimbus" -> UIManager.setLookAndFeel("javax.swing.plaf.nimbus.NimbusLookAndFeel");
                case "Motif" -> UIManager.setLookAndFeel("com.sun.java.swing.plaf.motif.MotifLookAndFeel");
                case "Windows" -> UIManager.setLookAndFeel("com.sun.java.swing.plaf.windows.WindowsLookAndFeel");
            }
            SwingUtilities.updateComponentTreeUI(this);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    public static void main(String[] args) {
        SwingUtilities.invokeLater(ProductApp::new);
    }
}
